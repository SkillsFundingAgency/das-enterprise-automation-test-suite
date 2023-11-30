namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public abstract class AanBasePage : VerifyBasePage
{
    protected readonly AANDataHelpers aanDataHelpers;

    private static By NetworkHubLink => By.CssSelector("a[href*='network-hub']");

    protected override By PageHeader => By.TagName("h1");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    protected static string DateFormat => Configurator.IsVstsExecution ? "MM-dd-yyyy" : "dd-MM-yyyy";

    public AanBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        aanDataHelpers = context.Get<AANDataHelpers>();

        if (verifyPage) VerifyPage();
    }

    public void ClickNetworkHubLink() => formCompletionHelper.Click(NetworkHubLink);
}

