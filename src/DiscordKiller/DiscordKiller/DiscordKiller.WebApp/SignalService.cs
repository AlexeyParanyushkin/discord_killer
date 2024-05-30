namespace DiscordKiller.WebApp;

public class SignalService
{
    public SignalService(ILogger<SignalService> logger)
    {
        HandleMessage += (uid, e) => logger.LogInformation("{uid}: {e}",uid, e);
    }
    
    public void PostMessage(string userId, string message)
    {
        HandleMessage?.Invoke(userId, message);
    }

    public event Action<string, string> HandleMessage;
}