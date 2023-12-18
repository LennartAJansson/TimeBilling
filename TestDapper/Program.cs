using TimeBilling.Domain.Abstract.Services;
using TimeBilling.Model;
using TimeBilling.Queries.Constants;
using TimeBilling.Queries.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      _ = services.AddQueriesRegistrations();
    })
    .Build();

await host.StartAsync();

using IServiceScope scope = host.Services.CreateScope();
IServiceProvider serviceProvider = scope.ServiceProvider;

ITimeBillingQueryService service = serviceProvider.GetRequiredService<ITimeBillingQueryService>();
ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();

IEnumerable<Customer> customers = await service.ReadCustomers();
Customer customer = await service.ReadCustomer(1);

IEnumerable<Person> people = await service.ReadPeople();
Person person = await service.ReadPerson(1);

IEnumerable<Workload> workloads = await service.ReadWorkloads();
Workload workload = await service.ReadWorkload(1);
IEnumerable<Workload> workloadsByCustomer = await service.ReadWorkloadsByCustomer(1);
IEnumerable<Workload> workloadsByPerson = await service.ReadWorkloadsByPerson(1);

Console.WriteLine(QueryStrings.ReadAllCustomers + ';');
Console.WriteLine(QueryStrings.ReadCustomerById + ';');
Console.WriteLine(QueryStrings.ReadAllPeople + ';');
Console.WriteLine(QueryStrings.ReadPersonById + ';');
Console.WriteLine(QueryStrings.ReadAllWorkloads + ';');
Console.WriteLine(QueryStrings.ReadWorkloadById + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByCustomer + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByPerson + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByCustomerWithPeople + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByPersonWithCustomer + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByCustomerWithCustomerAndPeople + ';');
Console.WriteLine(QueryStrings.ReadWorkloadsByPersonWithCustomerAndPeople + ';');