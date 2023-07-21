namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public abstract class AanBasePage : VerifyBasePage
{
    protected readonly AANDataHelpers aanDataHelpers;
    protected override By PageHeader => By.TagName("h1");

    protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");


    public AanBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        aanDataHelpers = context.Get<AANDataHelpers>();

        if (verifyPage) VerifyPage();
    }

}

