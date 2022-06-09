namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;

public class AO_HomePage : EPAO_BasePage
{
    protected override string PageTitle => "Find an assessment opportunity";

    #region Locators
    private static By ApprovedTab => By.Id("tab_approved");
    private static By InDevelopmentTab => By.Id("tab_in-development");
    private static By ProposedTab => By.Id("tab_proposed");
    private static By TabHeader => By.CssSelector("#main-content .govuk-heading-m");
    private static By AbattoirWorkerApprovedStandardLink => By.LinkText("Abattoir worker");
    private static By JourneymanBookbinderInDevelopmentStandardLink => By.LinkText("Journeyman bookbinder");
    private static By Nutritionist => By.LinkText("Nutritionist");
    #endregion

    public AO_HomePage(ScenarioContext context) : base(context)
    {
        VerifyPage();
        AcceptCookies();
    }

    public void VerifyApprovedTab()
    {
        VerifyElement(ApprovedTab);
        VerifyElement(TabHeader, "Approved Standards");
    }

    public AO_ApprovedStandardDetailsPage ClickOnAbattoirWorkerApprovedStandardLink()
    {
        formCompletionHelper.Click(AbattoirWorkerApprovedStandardLink);
        return new AO_ApprovedStandardDetailsPage(context);
    }

    public AO_HomePage ClickInDevelopmentTab()
    {
        formCompletionHelper.Click(InDevelopmentTab);
        return this;
    }

    public AO_InDevelopmentStandardDetailsPage ClickOnInDevelopmentStandardLink()
    {
        formCompletionHelper.Click(JourneymanBookbinderInDevelopmentStandardLink);
        return new AO_InDevelopmentStandardDetailsPage(context);
    }

    public AO_HomePage ClickInProposedTab()
    {
        formCompletionHelper.Click(ProposedTab);
        return this;
    }

    public AO_ProposedStandardDetailsPage ClickOnAProposedStandard()
    {
        formCompletionHelper.Click(Nutritionist);
        return new AO_ProposedStandardDetailsPage(context);
    }
}