namespace TimeBilling.Api.UnitTests;

using Microsoft.Extensions.DependencyInjection;

using TimeBilling.Contracts;
using TimeBilling.Domain.Abstract.Handlers;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public async Task TestAddingCustomerFromHandlerToDb()
    {
        //Arrange:
        IServiceProvider provider = TestHelper.GetServiceProvider();
        string expected = "Volvo";

        //Act:
        ICustomerHandlers handler = provider.GetRequiredService<ICustomerHandlers>();

        CustomerResponse? response = await handler.CreateCustomer(CreateCustomerCommand.Create(expected));

        //Assert:
        Assert.IsNotNull(response);
        Assert.AreEqual(expected, response.Name);
    }
}