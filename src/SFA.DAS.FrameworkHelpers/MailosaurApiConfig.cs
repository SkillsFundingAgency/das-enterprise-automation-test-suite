namespace SFA.DAS.FrameworkHelpers;

public abstract class MailosaurServerConfig
{
    public string ServerName { get; set; }

    public string ServerId { get; set; }

    public string ApiToken { get; set; }

}

public class MailosaurApiConfig : MailosaurServerConfig
{

}

public class MailosaurUser : MailosaurServerConfig
{
    private readonly List<(string Email, DateTime ReceviedAfter)> EmailList;

    public MailosaurUser(string serverName, string serverId, string apiToken)
    {
        ServerName = serverName;
        ServerId = serverId;
        ApiToken = apiToken;
        EmailList = [];
    }

    public string DomainName => $"{ServerId}.mailosaur.net";

    public void AddToEmailList(string email) => EmailList.Add((email, DateTime.Now));

    public List<(string Email, DateTime ReceviedAfter)> GetEmailList() => EmailList;
}
