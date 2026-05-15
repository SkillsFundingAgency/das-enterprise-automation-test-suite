using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;

public class LearnerHomePage(ScenarioContext context) : InterimApprenticesHomePage(context, false)
{
    private static By AddALearnerLink => By.LinkText("Add a Learner or send a learner request");
    private static By LearnerRequestsLink => By.LinkText("Review learner requests");
    private static By ManageLearnersLink => By.LinkText("Manage your Learners");
    private static By SetPaymentOrder => By.LinkText("Set payment order");
    private static By ReportPublicSectorApprenticeshipTarget => By.LinkText("Report public sector apprenticeship target");
    private static By Help => By.LinkText("Help");
    private static By AccessibilityStatement => By.LinkText("Accessibility statement");
    private static By Feedback => By.LinkText("Feedback");
    private static By Privacy => By.LinkText("Privacy");
    private static By Cookies => By.LinkText("Cookies");
    private static By BuiltBy => By.LinkText("Department for Education");
    private static By CrownCopyright => By.LinkText("© Crown copyright");
    private static By CookiesAcceptButton => By.Id("btn-cookie-accept");
    private static By CookiesSettingsButton => By.Id("btn-cookie-settings");
    private static By ZenHelpWidgetScript1 => By.Id("ze-snippet");
    private static By ZenHelpWidgetScript2 => By.Id("co-snippet");

    public AddAnApprenitcePage ClickAddALearnerLink()
    {
        formCompletionHelper.ClickElement(AddALearnerLink);
        return new AddAnApprenitcePage(context);
    }

    public AccessibilityStatementPage ClickAccessibilityStatement()
    {
        formCompletionHelper.ClickElement(AccessibilityStatement);
        return new AccessibilityStatementPage(context);
    }

    public ApprenticeRequestsPage ClickLearnerRequestsLink()
    {
        formCompletionHelper.ClickElement(LearnerRequestsLink);
        return new ApprenticeRequestsPage(context);
    }

    public ManageYourLearnersPage ClickManageYourLearnersLink()
    {
        formCompletionHelper.ClickElement(ManageLearnersLink);
        return new ManageYourLearnersPage(context);
    }

    internal InterimFinanceHomePage GoToFinancePage() => new(context, true);

    public SetpaymentOrderPage ClickSetPaymentOrderLink()
    {
        formCompletionHelper.ClickElement(SetPaymentOrder);
        return new SetpaymentOrderPage(context);
    }

    public ReportPublicSectorApprenticeshipTargetPage ClickReportPublicSectorApprenticeshipTargetLink()
    {
        formCompletionHelper.ClickElement(ReportPublicSectorApprenticeshipTarget);
        return new ReportPublicSectorApprenticeshipTargetPage(context);
    }

    public LearnerHomePage ValidateFooter()
    {
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Help), "Validate Help link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Feedback), "Validate Feedback link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Privacy), "Validate Privacy link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(AccessibilityStatement), "Validate Accessibility Statement link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Cookies), "Validate Cookies link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(BuiltBy), "Validate BuiltBy link on the footer of the page");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CrownCopyright), "Validate CrownCopyright link on the footer of the page");

        return this;
    }

    public LearnerHomePage ValidateCookiesBanner()
    {
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CookiesAcceptButton), "Validate accept cookies button on cookies banner");
        Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CookiesSettingsButton), "Validate cookie settings button on cookies banner");
        return this;
    }

    public LearnerHomePage ValidateHelpWidget()
    {
        Assert.IsTrue(pageInteractionHelper.IsElementPresent(ZenHelpWidgetScript1), "Validate help widget button in the bottom right");
        Assert.IsTrue(pageInteractionHelper.IsElementPresent(ZenHelpWidgetScript2), "Validate help widget button in the bottom right");
        return this;
    }
}

