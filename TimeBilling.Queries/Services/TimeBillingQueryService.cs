namespace TimeBilling.Queries.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MySql.Data.MySqlClient;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;
using TimeBilling.Queries.Constants;

public sealed class TimeBillingQueryService : ITimeBillingQueryService
{
  private readonly ILogger<TimeBillingQueryService> logger;
  private readonly IConfiguration configuration;
  private readonly string connectionString = string.Empty;

  public TimeBillingQueryService(ILogger<TimeBillingQueryService> logger, IConfiguration configuration)
  {
    this.logger = logger;
    this.configuration = configuration;
    connectionString = configuration.GetConnectionString("TimeBillingDb")
      ?? throw new ArgumentException("No connectionstring");
  }
  public async Task<IEnumerable<Customer>> ReadCustomers()
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadAllCustomers;
    logger.LogTrace(sql);

    IEnumerable<Customer> customers = await connection.QueryAsync<Customer>(sql);

    foreach (Customer customer in customers)
    {
      customer.Workloads = (await ReadWorkloadsWithPersonByCustomer(customer.Id)).ToList();
    }

    return customers;
  }

  public async Task<Customer?> ReadCustomer(int customerId, bool relate = true)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadCustomerById;
    logger.LogTrace(sql);

    Customer customer = await connection.QuerySingleAsync<Customer>(sql, new { CustomerId = customerId });
    if (relate)
    {
      customer.Workloads = (await ReadWorkloadsWithPersonByCustomer(customerId)).ToList();
    }

    return customer;
  }

  public async Task<IEnumerable<Person>> ReadPeople()
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadAllPeople;
    logger.LogTrace(sql);

    IEnumerable<Person> people = await connection.QueryAsync<Person>(sql);

    foreach (Person person in people)
    {
      person.Workloads = (await ReadWorkloadsWithCustomerByPerson(person.Id)).ToList();
    }

    return people;
  }

  public async Task<Person?> ReadPerson(int personId, bool relate = true)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadPersonById;
    logger.LogTrace(sql);

    Person person = await connection.QuerySingleAsync<Person>(sql, new { PersonId = personId });
    if (relate)
    {
      person.Workloads = (await ReadWorkloadsWithCustomerByPerson(personId)).ToList();
    }

    return person;
  }

  public async Task<IEnumerable<Workload>> ReadWorkloads()
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadAllWorkloads;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = await connection.QueryAsync<Workload>(sql);
    foreach (Workload workload in workloads)
    {
      workload.Customer = await ReadCustomer(workload.CustomerId);
      workload.Person = await ReadPerson(workload.PersonId);
    }

    return workloads;
  }


  public async Task<Workload?> ReadWorkload(int workloadId)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadWorkloadById;
    logger.LogTrace(sql);

    Workload workload = await connection.QuerySingleAsync<Workload>(sql, new { WorkloadId = workloadId });
    workload.Customer = await ReadCustomer(workload.CustomerId);
    workload.Person = await ReadPerson(workload.PersonId);

    return workload;
  }

  public async Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(int customerId)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadWorkloadsByCustomer;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = await connection.QueryAsync<Workload>(sql, new { CustomerId = customerId });
    foreach (Workload workload in workloads)
    {
      workload.Person = await ReadPerson(workload.PersonId);
    }

    return workloads;
  }

  public async Task<IEnumerable<Workload>> ReadWorkloadsByPerson(int personId)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadWorkloadsByPerson;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = await connection.QueryAsync<Workload>(sql, new { PersonId = personId });
    foreach (Workload workload in workloads)
    {
      workload.Customer = await ReadCustomer(workload.CustomerId);
    }

    return workloads;
  }

  private async Task<IEnumerable<Workload>> ReadWorkloadsWithPersonByCustomer(int customerId)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadWorkloadsByCustomer;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = await connection.QueryAsync<Workload>(sql, new { CustomerId = customerId });

    foreach (Workload workload in workloads)
    {
      //workload.Customer = await ReadCustomer(workload.CustomerId, false);
      workload.Person = await ReadPerson(workload.PersonId, false);
      logger.LogTrace($"Workload {workload.Id} has person {workload.PersonId} with {workload.Person.Workloads.Count} workloads");
    }

    return workloads;
  }

  private async Task<IEnumerable<Workload>> ReadWorkloadsWithCustomerByPerson(int personId)
  {
    using MySqlConnection connection = new(connectionString);
    string sql = QueryStrings.ReadWorkloadsByPerson;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = await connection.QueryAsync<Workload>(sql, new { PersonId = personId });

    foreach (Workload workload in workloads)
    {
      workload.Customer = await ReadCustomer(workload.CustomerId, false);
      //workload.Person = await ReadPerson(workload.PersonId, false);
      logger.LogTrace($"Workload {workload.Id} has customer {workload.CustomerId} with {workload.Customer.Workloads.Count} workloads");
    }

    return workloads;
  }
}
