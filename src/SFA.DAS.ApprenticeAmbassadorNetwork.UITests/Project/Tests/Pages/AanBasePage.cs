namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public abstract class AanBasePage : VerifyBasePage
{
    protected readonly AANDataHelpers aanDataHelpers;

    protected override By PageHeader => By.TagName("h1");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

    protected static By EventTag => By.CssSelector(".govuk-tag.app-tag");

    protected static string DateFormat => Configurator.IsVstsExecution ? "MM-dd-yyyy" : "dd-MM-yyyy";

    public AanBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        aanDataHelpers = context.Get<AANDataHelpers>();

        if (verifyPage) VerifyPage();
    }
}

