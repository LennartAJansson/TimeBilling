namespace TimeBilling.Persistance.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;
using TimeBilling.Persistance.Context;


//TODO! Take Explicitly Loading of relations in consideration
internal sealed class TimeBillingService : ITimeBillingService
{
  private readonly ILogger<TimeBillingService> logger;
  private readonly ITimeBillingDbContext context;

  public TimeBillingService(ILogger<TimeBillingService> logger, ITimeBillingDbContext context)
  {
    this.logger = logger;
    this.context = context;
  }

  public async Task<Customer> CreateCustomer(Customer customer)
  {
    _ = context.Add(customer);
    _ = await context.SaveChangesAsync();
    context.Entry(customer).Collection(p => p.Workloads).Load();

    return customer;
  }

  public async Task<Person> CreatePerson(Person person)
  {
    _ = context.Add(person);
    _ = await context.SaveChangesAsync();
    context.Entry(person).Collection(p => p.Workloads).Load();

    return person;
  }

  public async Task<Workload> CreateWorkload(Workload workload)
  {
    _ = context.Add(workload);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(workload).Reference(p => p.Customer).Load();
    context.Entry(workload).Reference(p => p.Person).Load();

    return workload;
  }

  public async Task<Customer?> DeleteCustomer(int customerId)
  {
    Customer? customer = await context.Customers.FindAsync(customerId);
    if (customer is null)
    {
      return null;
    }
    context.Entry(customer).Collection(p => p.Workloads).Load();

    _ = context.Remove(customer);
    _ = await context.SaveChangesAsync();

    return customer;
  }

  public async Task<Person?> DeletePerson(int personId)
  {
    Person? person = await context.People.FindAsync(personId);
    if (person is null)
    {
      return null;
    }
    context.Entry(person).Collection(p => p.Workloads).Load();

    _ = context.Remove(person);
    _ = await context.SaveChangesAsync();

    return person;
  }

  public async Task<Workload?> DeleteWorkload(int workloadId)
  {
    Workload? workload = await context.Workloads.FindAsync(workloadId);
    if (workload is null)
    {
      return null;
    }

    //Explicitly Loading
    context.Entry(workload).Reference(p => p.Customer).Load();
    context.Entry(workload).Reference(p => p.Person).Load();

    _ = context.Remove(workload);
    _ = await context.SaveChangesAsync();

    return workload;
  }

  public async Task<Customer?> ReadCustomer(int customerId)
  {
    Customer? customer = await context.Customers.FindAsync(customerId);
    if (customer is null)
    {
      return null;
    }
    context.Entry(customer).Collection(p => p.Workloads).Load(Microsoft.EntityFrameworkCore.ChangeTracking.LoadOptions.ForceIdentityResolution);
    foreach (Workload workload in customer.Workloads)
    {
      context.Entry(workload).Reference(p => p.Person).Load();
    }
    return customer;
  }

  public Task<IEnumerable<Customer>> ReadCustomers()
  {
    IEnumerable<Customer> customers = context.Customers
      .Include("Workloads")
      .Include("Workloads.Person")
      .AsEnumerable();
    return Task.FromResult(customers);
  }

  public async Task<Person?> ReadPerson(int personId)
  {
    Person? person = await context.People.FindAsync(personId);
    if (person is null)
    {
      return null;
    }
    context.Entry(person).Collection(p => p.Workloads).Load(Microsoft.EntityFrameworkCore.ChangeTracking.LoadOptions.ForceIdentityResolution);
    foreach (Workload workload in person.Workloads)
    {
      context.Entry(workload).Reference(p => p.Customer).Load();
    }
    return person;
  }

  public Task<IEnumerable<Person>> ReadPeople()
  {
    IEnumerable<Person> people = context.People
      .Include("Workloads")
      .Include("Workloads.Customer")
      .AsEnumerable();
    return Task.FromResult(people);
  }

  public Task<Workload?> ReadWorkload(int workloadId)
  {
    Workload? workload = context.Workloads
      .Include("Customer")
      .Include("Person")
      .FirstOrDefault(w => w.Id.Equals(workloadId));
    return Task.FromResult(workload);
  }

  public Task<IEnumerable<Workload>> ReadWorkloads()
  {
    IEnumerable<Workload> workloads = context.Workloads
      .Include("Customer")
      .Include("Person")
      .AsEnumerable();
    return Task.FromResult(workloads);
  }

  public Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(int customerId)
  {
    IEnumerable<Workload> workloads = context.Workloads
      .Include("Customer")
      .Include("Person")
      .Where(w => w.CustomerId.Equals(customerId))
      .AsEnumerable();
    return Task.FromResult(workloads);
  }

  public Task<IEnumerable<Workload>> ReadWorkloadsByPerson(int personId)
  {
    IEnumerable<Workload> workloads = context.Workloads
      .Include("Customer")
      .Include("Person")
      .Where(w => w.PersonId.Equals(personId))
      .AsEnumerable();
    return Task.FromResult(workloads);
  }

  public async Task<Customer?> UpdateCustomer(Customer customer)
  {
    _ = context.Update(customer);
    _ = await context.SaveChangesAsync();
    context.Entry(customer).Collection(p => p.Workloads).Load();
    return customer;
  }

  public async Task<Person?> UpdatePerson(Person person)
  {
    _ = context.Update(person);
    _ = await context.SaveChangesAsync();
    context.Entry(person).Collection(p => p.Workloads).Load();
    return person;
  }

  public async Task<Workload?> UpdateWorkload(Workload workload)
  {
    _ = context.Update(workload);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(workload).Reference(p => p.Customer).Load();
    context.Entry(workload).Reference(p => p.Person).Load();

    return workload;
  }
}
