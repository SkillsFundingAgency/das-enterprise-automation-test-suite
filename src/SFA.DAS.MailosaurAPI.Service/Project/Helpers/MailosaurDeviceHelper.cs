using Mailosaur;

namespace SFA.DAS.MailosaurAPI.Service.Project.Helpers;

public class MailosaurDeviceHelper(string apiToken)
{
    public string GetCode(string deviceId)
    {
        var mailosaur = new MailosaurClient(apiToken);

        var result = mailosaur.Devices.Otp(deviceId);

        return result.Code;
    }
}
