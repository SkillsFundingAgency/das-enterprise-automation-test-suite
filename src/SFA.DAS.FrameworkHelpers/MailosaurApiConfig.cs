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
    public string DomainName => $"{ServerId}.mailosaur.net";

    public List<(string Email, DateTime ReceviedAfter)> EmailList { get; set; }

    public void AddEmail(string email) => EmailList.Add((email, DateTime.Now));
}
