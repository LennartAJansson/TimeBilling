namespace TimeBilling.Common.Messaging.Services;

using TimeBilling.Common.Contracts;

public interface ICommandSender
{
  bool IsConnected { get; }
  //TODO Change this so it uses an ICommand:
  Task<CommandResponse> SendAsync(object command);
}


