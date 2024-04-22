using SFA.DAS.MailosaurAPI.Service.Project.Helpers;

namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public class EnterYourSecurityCodePage(ScenarioContext context) : LiveRegistrationBasePage(context)
{
    protected override string PageTitle => "Enter the 6 digit security code shown in your authenticator app";

    protected override By PageHeader => By.CssSelector(".govuk-label--l");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By CodeField => By.CssSelector("#code");

    public LiveHomePage EnterCode()
    {
        var deviceConfig = context.Get<MailasourDeviceConfig>();

        var helper = new MailosaurDeviceHelper(deviceConfig.AccountApiToken);

        var code = helper.GetCode(deviceConfig.LiveEasUserDeviceId);

        formCompletionHelper.EnterPpi(CodeField, code);

        Continue();

        return new(context);
    }
}
