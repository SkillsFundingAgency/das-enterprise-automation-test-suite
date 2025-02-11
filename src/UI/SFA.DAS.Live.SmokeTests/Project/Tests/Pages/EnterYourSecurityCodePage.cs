using SFA.DAS.MailosaurAPI.Service.Project.Helpers;

namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public class EnterYourSecurityCodePage(ScenarioContext context) : LiveSignBasePage(context)
{
    protected override string PageTitle => "Enter the 6 digit security code shown in your authenticator app";

    private static By CodeField => By.CssSelector("#code");

    public void EnterCode()
    {
        var deviceConfig = context.Get<MailasourDeviceConfig>();

        var helper = new MailosaurDeviceHelper(deviceConfig.AccountApiToken);

        var code = helper.GetCode(deviceConfig.LiveEasUserDeviceId);

        EnterPpiAndContinue(CodeField, code);
    }
}
