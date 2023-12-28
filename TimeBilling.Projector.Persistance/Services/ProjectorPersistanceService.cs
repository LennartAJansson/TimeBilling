namespace TimeBilling.Projector.Persistance.Services;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using TimeBilling.Model;
using TimeBilling.Projector.Domain.Abstract.Services;
using TimeBilling.Projector.Persistance.Context;

internal sealed class ProjectorPersistanceService : IProjectorPersistanceService
{
  private readonly ILogger<ProjectorPersistanceService> logger;
  private readonly ITimeBillingDbContext context;

  public ProjectorPersistanceService(ILogger<ProjectorPersistanceService> logger, ITimeBillingDbContext context)
  {
    this.logger = logger;
    this.context = context;
  }

  public async Task<Customer> CreateCustomer(Customer customer)
  {
    _ = context.Add(customer);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(customer).Collection(p => p.Workloads).Load();

    return customer;
  }

  public async Task<Person> CreatePerson(Person person)
  {
    _ = context.Add(person);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
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

  public async Task<Customer?> UpdateCustomer(Customer customer)
  {
    _ = context.Update(customer);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(customer).Collection(p => p.Workloads).Load();

    return customer;
  }

  public async Task<Person?> UpdatePerson(Person person)
  {
    _ = context.Update(person);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(person).Collection(p => p.Workloads).Load();

    return person;
  }

  public async Task<Workload?> UpdateWorkload(Guid workloadId, DateTimeOffset end)
  {
    Workload? workload = await context.Workloads.FindAsync(workloadId);
    if (workload is null)
    {
      return null;
    }

    workload.End = end;
    _ = context.Update(workload);
    _ = await context.SaveChangesAsync();

    //Explicitly Loading
    context.Entry(workload).Reference(p => p.Customer).Load();
    context.Entry(workload).Reference(p => p.Person).Load();

    return workload;
  }

  public async Task<Customer?> DeleteCustomer(Guid customerId)
  {
    Customer? customer = await context.Customers.FindAsync(customerId);
    if (customer is null)
    {
      return null;
    }

    //Explicitly Loading
    context.Entry(customer).Collection(p => p.Workloads).Load();

    _ = context.Remove(customer);
    _ = await context.SaveChangesAsync();

    return customer;
  }

  public async Task<Person?> DeletePerson(Guid personId)
  {
    Person? person = await context.People.FindAsync(personId);
    if (person is null)
    {
      return null;
    }

    //Explicitly Loading
    context.Entry(person).Collection(p => p.Workloads).Load();

    _ = context.Remove(person);
    _ = await context.SaveChangesAsync();

    return person;
  }

  public async Task<Workload?> DeleteWorkload(Guid workloadId)
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
}
