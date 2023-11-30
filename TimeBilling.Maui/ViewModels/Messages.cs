namespace TimeBilling.Maui.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

using TimeBilling.Maui.Models;

public sealed class SelectedPersonChanged(Person? person) : ValueChangedMessage<Person>(person!) { }
public sealed class RefreshPeopleList(Person? person) : ValueChangedMessage<Person>(person!) { }

public sealed class SelectedCustomerChanged(Customer? customer) : ValueChangedMessage<Customer>(customer!) { }
public sealed class RefreshCustomersList(Customer? customer) : ValueChangedMessage<Customer>(customer!) { }

public sealed class SelectedWorkloadChanged(Workload? workload) : ValueChangedMessage<Workload>(workload!) { }
public sealed class RefreshWorkloadsList(Workload? workload) : ValueChangedMessage<Workload>(workload!) { }
