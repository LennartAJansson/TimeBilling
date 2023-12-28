namespace TimeBilling.Projector.Domain.Mediators;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using TimeBilling.Common.Contracts;
using TimeBilling.Common.Messaging.Contracts;
using TimeBilling.Model;
using TimeBilling.Projector.Domain.Abstract.Services;

public sealed class CustomerProjectorCommandMediator(ILogger<CustomerProjectorCommandMediator> logger, IMapper mapper, IProjectorPersistanceService service) :
    IRequestHandler<CreateCustomerCommand, CommandResponse>,
    IRequestHandler<UpdateCustomerCommand, CommandResponse>,
    IRequestHandler<DeleteCustomerCommand, CommandResponse>
{
  private readonly ILogger<CustomerProjectorCommandMediator> logger = logger;
  private readonly IMapper mapper = mapper;
  private readonly IProjectorPersistanceService service = service;

  public async Task<CommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer customer = mapper.Map<Customer>(request);
    Customer result = await service.CreateCustomer(customer);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Customer with id: {result.Id} created") :
      CommandResponse.Create(false, $"Customer with id: {request.CustomerId} NOT created");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer customer = mapper.Map<Customer>(request);
    Customer? result = await service.UpdateCustomer(customer);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Customer with id: {result.Id} updated") :
      CommandResponse.Create(false, $"Customer with id: {request.CustomerId} NOT updated");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }

  public async Task<CommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
  {
    Customer? result = await service.DeleteCustomer(request.CustomerId);

    CommandResponse response = result is not null ?
      CommandResponse.Create(true, $"Customer with id: {result.Id} deleted") :
      CommandResponse.Create(false, $"Customer with id: {request.CustomerId} NOT deleted");

    if (logger.IsEnabled(LogLevel.Debug))
    {
      logger.LogDebug("Response: {response}", response);
    }

    return response;
  }
}

