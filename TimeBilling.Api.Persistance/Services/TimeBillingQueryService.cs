namespace TimeBilling.Api.Persistance.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MySql.Data.MySqlClient;

using TimeBilling.Api.Domain.Abstract.Services;
using TimeBilling.Api.Persistance.Constants;

using TimeBilling.Model;

public sealed class TimeBillingQueryService : ITimeBillingQueryService
{
  private readonly ILogger<TimeBillingQueryService> logger;
  private readonly string connectionString = string.Empty;

  public TimeBillingQueryService(ILogger<TimeBillingQueryService> logger, IConfiguration configuration)
  {
    this.logger = logger;
    connectionString = configuration.GetConnectionString("TimeBillingDb")
      ?? throw new ArgumentException("No connectionstring");
  }
  public Task<IEnumerable<Customer>> ReadCustomers()
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadCustomersWithWorkloadsAndPerson;
    logger.LogInformation(sql);

    IEnumerable<Customer> customer = connection.Query<Customer, Workload, Person, Customer>(sql, map: (c, w, p) =>
    {
      c.Workloads.Add(w);
      w.Person = p;
      return c;
    });

    IEnumerable<Customer> result = customer.GroupBy(c => c.Id).Select(g =>
    {
      Customer groupedCustomer = g.First();
      groupedCustomer.Workloads = g
        .Select(p => p.Workloads.Single()).ToList();
      return groupedCustomer;
    }).ToList();

    return Task.FromResult(result);
  }

  public Task<Customer?> ReadCustomer(Guid customerId)
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadCustomerWithWorkloadsAndPersonByCustomer;
    logger.LogTrace(sql);

    IEnumerable<Customer> customer = connection.Query<Customer, Workload, Person, Customer>(sql, param: new { CustomerId = customerId },
      map: (c, w, p) =>
      {
        w.Person = p;
        c.Workloads.Add(w);
        return c;
      });

    Customer? result = customer.GroupBy(c => c.Id).Select(g =>
    {
      Customer groupedCustomer = g.First();
      groupedCustomer.Workloads = g
        .Select(p => p.Workloads.Single()).ToList();
      return groupedCustomer;
    }).SingleOrDefault();

    return Task.FromResult(result);
  }

  public Task<IEnumerable<Person>> ReadPeople()
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadPeopleWithWorkloadsAndCustomer;
    logger.LogInformation(sql);

    IEnumerable<Person> people = connection.Query<Person, Workload, Customer, Person>(sql, map: (p, w, c) =>
    {
      p.Workloads.Add(w);
      w.Customer = c;
      return p;
    });

    IEnumerable<Person> result = people.GroupBy(p => p.Id).Select(g =>
    {
      Person groupedPerson = g.First();
      groupedPerson.Workloads = g.Select(p => p.Workloads.Single()).ToList();
      return groupedPerson;
    }).ToList();

    return Task.FromResult(result);
  }

  public Task<Person?> ReadPerson(Guid personId)
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadPersonWithWorkloadsAndCustomerByPerson;
    logger.LogTrace(sql);

    IEnumerable<Person> people = connection.Query<Person, Workload, Customer, Person>(sql, param: new { PersonId = personId },
      map: (p, w, c) =>
      {
        w.Customer = c;
        p.Workloads.Add(w);
        return p;
      });

    Person? result = people.GroupBy(p => p.Id).Select(g =>
    {
      Person groupedPerson = g.First();
      groupedPerson.Workloads = g
        .Select(p => p.Workloads.Single()).ToList();
      return groupedPerson;
    }).SingleOrDefault();

    return Task.FromResult(result);
  }

  public Task<IEnumerable<Workload>> ReadWorkloads()
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadWorkloadsWithCustomerAndPeople;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = connection.Query<Workload, Customer, Person, Workload>(sql, map: (w, c, p) =>
    {
      w.Customer = c;
      w.Person = p;
      return w;
    });

    return Task.FromResult(workloads);
  }


  public Task<Workload?> ReadWorkload(Guid workloadId)
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadWorkloadWithCustomerAndPeopleById;
    logger.LogTrace(sql);

    Workload? workload = connection.Query<Workload, Customer, Person, Workload>(sql, param: new { WorkloadId = workloadId },
      map: (w, c, p) =>
      {
        w.Customer = c;
        w.Person = p;
        return w;
      }).FirstOrDefault();

    return Task.FromResult(workload);
  }

  public Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(Guid customerId)
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadWorkloadsWithCustomerAndPeopleByCustomer;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = connection.Query<Workload, Customer, Person, Workload>(sql, param: new { CustomerId = customerId },
      map: (w, c, p) =>
      {
        w.Customer = c;
        w.Person = p;
        return w;
      });

    return Task.FromResult(workloads);
  }

  public Task<IEnumerable<Workload>> ReadWorkloadsByPerson(Guid personId)
  {
    using MySqlConnection connection = new(connectionString);

    string sql = QueryStrings.ReadWorkloadsWithCustomerAndPeopleByPerson;
    logger.LogTrace(sql);

    IEnumerable<Workload> workloads = connection.Query<Workload, Customer, Person, Workload>(sql, param: new { PersonId = personId },
      map: (w, c, p) =>
      {
        w.Customer = c;
        w.Person = p;
        return w;
      });

    return Task.FromResult(workloads);
  }
}
