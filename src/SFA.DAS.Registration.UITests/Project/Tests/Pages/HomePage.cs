namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class HomePage : InterimHomeBasePage
{
    #region Locators

    protected static By FindApprenticeshipLink => By.LinkText("Find apprenticeship training and manage requests");
    protected static By StartNowButton => By.LinkText("Start now");
    protected static By YourFundingReservationsLink => By.LinkText("Your funding reservations");
    protected static By YourTransfersLink => By.LinkText("Your transfers");
    private static By SucessSummary => By.CssSelector(".das-notification");
    private static By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
    private static By ContinueTo => By.LinkText("Continue");
    private static By SetUpAnApprenticeshipSectionHeader => By.Id("set-up-an-apprenticeship");
    protected static By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
    protected static By YourFinancesLink => By.LinkText("Your finances");
    protected static By AANLink => By.LinkText("Join the Apprentice Ambassador Network");
    private static By TransferRequestViewDetailsLink => By.XPath("//li[contains(span, 'Transfer request received')]/span/a[text()='View details']");
    private static By TransferConnectionRequestViewDetailsLink => By.XPath("//li[contains(span, 'connection requests to review')]/span/a[text()='View details']");
    #endregion

    protected override string AccessibilityPageTitle => "Employer home page";

    public HomePage(ScenarioContext context, bool navigate) : base(context, navigate) => AcceptCookies();

    public HomePage(ScenarioContext context) : this(context, false) { }

    public void GoToAanHomePage() => formCompletionHelper.Click(AANLink);

    public HomePage VerifySucessSummary(string message)
    {
        pageInteractionHelper.VerifyText(SucessSummary, message);
        return this;
    }

    public HomePage VerifyAccountName(string name)
    {
        pageInteractionHelper.VerifyText(PageHeader, name);
        return this;
    }

    public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
    {
        formCompletionHelper.Click(AcceptYourAgreementLink);
        return new AboutYourAgreementPage(context);
    }

    public void ContinueToCreateAdvert() => formCompletionHelper.ClickElement(ContinueTo);

    public void VerifySetupAnApprenticeshipSection()
    {
        VerifyElement(SetUpAnApprenticeshipSectionHeader);
        VerifyElement(StartNowButton);
    }

    public void VerifyLevyDeclarationDueTaskMessageShown()
    {
        var messageText = $"Levy declaration due by 19 {DateTime.Now:MMMM}";
        var xpath = $"//span[contains(text(), '{messageText}')]";
        var levyDeclarationDue = By.XPath(xpath);

        VerifyElement(levyDeclarationDue);
    }

    public void VerifyApprenticeChangeToReviewMessageShown(int numberOfChanges)
    {
        var messageText = numberOfChanges == 1 ? "1 apprentice change to review" : $"{numberOfChanges} apprentice changes to review";
        var xpath = $"//span[contains(text(), '{messageText}')]";
        var apprenticeChangeToReviewMessage = By.XPath(xpath);

        VerifyElement(apprenticeChangeToReviewMessage);
    }

    public void VerifyApprenticeRequestsReadyToReviewMessageShown(int numberOfChanges)
    {
        var messageText = numberOfChanges == 1 ? "1 apprentice request ready for review" : $"{numberOfChanges} apprentice requests ready for review";
        var xpath = $"//span[contains(text(), '{messageText}')]";
        var apprenticeRequestsToReviewMessage = By.XPath(xpath);

        VerifyElement(apprenticeRequestsToReviewMessage);
    }

    public void VerifyTransferPledgeApplicationsToReviewMessageShown(int numberOfChanges)
    {
        var messageText = numberOfChanges == 1 ? "1 transfer pledge application awaiting your approval" : $"{numberOfChanges} transfer pledge applications awaiting your approval";
        var xpath = $"//span[contains(text(), '{messageText}')]";
        var transferApplicationsToReviewMessage = By.XPath(xpath);

        VerifyElement(transferApplicationsToReviewMessage);
    }

    public void VerifyTransferRequestReceivedMessageShown()
    {
        var xpath = "//span[contains(text(), 'Transfer request received')]";
        var transferRequestMessage = By.XPath(xpath);

        VerifyElement(transferRequestMessage);
    }

    public void VerifyTransferConnectionRequestsMessageShown(int numberOfChanges)
    {
        var messageText = numberOfChanges == 1 ? "1 connection request to review" : $"{numberOfChanges} connection requests to review";
        var xpath = $"//span[contains(text(), '{messageText}')]";
        var cohortsToReviewMessage = By.XPath(xpath);

        VerifyElement(cohortsToReviewMessage);
    }

    public ManageYourApprenticesPage ClickViewChangesForApprenticeChangesToReview(int numberOfChanges)
    {
        var linkText = numberOfChanges == 1 ? "change" : "changes";
        var apprenticeChangeToReviewLink = By.XPath($"//a[contains(., 'View') and contains(., 'apprentice') and contains(., '{linkText}')]");

        formCompletionHelper.Click(apprenticeChangeToReviewLink);
        return new ManageYourApprenticesPage(context);
    }

    public ApprenticeRequestsPage ClickViewApprenticeRequestsForApprenticeRequestsToReview(int numberOfChanges)
    {
        var linkText = numberOfChanges == 1 ? "View apprentice request" : "View apprentice requests";
        var cohortsToApproveLink = By.LinkText(linkText);

        formCompletionHelper.Click(cohortsToApproveLink);
        return new ApprenticeRequestsPage(context);
    }

    public TransfersPage ClickViewDetailsForTransferRequests()
    {
        formCompletionHelper.Click(TransferRequestViewDetailsLink);
        return new TransfersPage(context);
    }

    public TransfersPage ClickViewDetailsForTransferConnectionRequests()
    {
        formCompletionHelper.Click(TransferConnectionRequestViewDetailsLink);
        return new TransfersPage(context);
    }

    public MyTransferPledgesPage ClickViewTransferPledgeApplications(int numberOfChanges)
    {
        var linkText = numberOfChanges == 1 ? "application" : "applications";
        var transferPledgeApplicationsLink = By.XPath($"//a[contains(., 'View') and contains(., 'transfer pledge') and contains(., '{linkText}')]");

        formCompletionHelper.Click(transferPledgeApplicationsLink);
        return new MyTransferPledgesPage(context);
    }
}