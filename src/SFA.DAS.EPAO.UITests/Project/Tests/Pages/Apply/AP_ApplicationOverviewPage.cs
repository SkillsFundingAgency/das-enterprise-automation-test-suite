using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;

public class AP_ApplicationOverviewPage : EPAO_BasePage
{
    protected override string PageTitle => "Application overview";
    private static string OrganisationDetailsSectionCompletedText => "13 of 13 questions completed";
    private static string DeclarationsSectionCompletedText => "20 of 20 questions completed";
    private static string FHASectionCompletedText => "1 of 1 questions completed";

    #region Locators
    private static By GoToOrganisationDetailsLink => By.LinkText("Go to organisation details");
    private static By GoToDeclarationsLink => By.LinkText("Go to declarations");
    private static By GoToFinancialHealthAssessmentLink => By.LinkText("Go to financial health assessment");
    private static By OrganisationDetailsSectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[1]");
    private static By DeclarationsSectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[2]");
    private static By FHASectionCompletedTextLabel => By.XPath("(//span[@id='company-details-hint'])[3]");
    private static By CancelAStandardLink => By.XPath("(//p[@class='govuk-body'])[4]");
    #endregion

    public AP_ApplicationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OrganisationDetailsBasePage ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
    {
        formCompletionHelper.Click(GoToOrganisationDetailsLink);
        return new(context);
    }

    public AP_DeclarationsBasePage ClickGoToDeclarationsLinkInApplicationOverviewPage()
    {
        formCompletionHelper.Click(GoToDeclarationsLink);
        return new(context);
    }

    public bool GoToFinancialHealthAssessmentLinkExists() => pageInteractionHelper.IsElementDisplayed(GoToFinancialHealthAssessmentLink);

    public AP_FHABasePage ClickGoToFinancialHealthAssessmentLinkInApplicationOverviewPage()
    {
        formCompletionHelper.Click(GoToFinancialHealthAssessmentLink);
        return new(context);
    }

    public AP_ApplicationSubmittedPage ClickSubmitInApplicationOverviewPage()
    {
        Continue();
        return new(context);
    }

    public AP_ApplicationOverviewPage VerifyOrganisationDetailsSectionCompletedText()
    {
        pageInteractionHelper.VerifyText(OrganisationDetailsSectionCompletedTextLabel, OrganisationDetailsSectionCompletedText);
        return this;
    }

    public AP_ApplicationOverviewPage VerifyDeclarationsSectionCompletedText()
    {
        pageInteractionHelper.VerifyText(DeclarationsSectionCompletedTextLabel, DeclarationsSectionCompletedText);
        return this;
    }

    public AP_ApplicationOverviewPage VerifyFHASectionCompletedText()
    {
        pageInteractionHelper.VerifyText(FHASectionCompletedTextLabel, FHASectionCompletedText);
        return this;
    }

    public AP_OSC01_AreYouSureYouWantToCancelThisStandardPage ClickToCancelYourStandardApplication()
    {
        formCompletionHelper.Click(CancelAStandardLink);
        return new(context);
    }
}