using AutoMapper;

using MediatR;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      _ = services.AddDomainRegistrations();
      _ = services.AddPersistanceRegistrations();
    })
    .Build();

await host.StartAsync();

using IServiceScope scope = host.Services.CreateScope();
IServiceProvider serviceProvider = scope.ServiceProvider;

ITimeBillingQueryService service = serviceProvider.GetRequiredService<ITimeBillingQueryService>();
IMapper mapper = serviceProvider.GetRequiredService<IMapper>();
IMediator mediator = serviceProvider.GetRequiredService<IMediator>();
ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();

IEnumerable<CustomerResponse> customers = mapper.Map<IEnumerable<CustomerResponse>>(await service.ReadCustomers());
CustomerResponse? customer = mapper.Map<CustomerResponse>(await service.ReadCustomer(1));

IEnumerable<PersonResponse> people = mapper.Map<IEnumerable<PersonResponse>>(await service.ReadPeople());
PersonResponse? person = mapper.Map<PersonResponse>(await service.ReadPerson(1));

IEnumerable<WorkloadResponse> workloads = mapper.Map<IEnumerable<WorkloadResponse>>(await service.ReadWorkloads());
WorkloadResponse? workload = mapper.Map<WorkloadResponse>(await service.ReadWorkload(1));
IEnumerable<WorkloadResponse> workloadsByCustomer = mapper.Map<IEnumerable<WorkloadResponse>>(await service.ReadWorkloadsByCustomer(1));
IEnumerable<WorkloadResponse> workloadsByPerson = mapper.Map<IEnumerable<WorkloadResponse>>(await service.ReadWorkloadsByPerson(1));

Console.WriteLine();
Console.WriteLine(customers.Combine());
Console.WriteLine();
Console.WriteLine(customer);
Console.WriteLine();
Console.WriteLine(people.Combine());
Console.WriteLine();
Console.WriteLine(person);
Console.WriteLine(workloads.Combine());
Console.WriteLine();
Console.WriteLine(workload);
Console.WriteLine();
Console.WriteLine(workloadsByCustomer.Combine());
Console.WriteLine();
Console.WriteLine(workloadsByPerson.Combine());
