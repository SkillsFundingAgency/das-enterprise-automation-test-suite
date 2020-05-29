using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticesHomePage : InterimApprenticesHomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By AddAnApprenticeLink => By.LinkText("Add an apprentice");
        private By YourCohortsLink => By.LinkText("Your cohorts");
        private By ManageYourApprenticesLink => By.LinkText("Manage your apprentices");
        private By SetPaymentOrder => By.LinkText("Set payment order");
        private By ReportPublicSectorApprenticeshipTarget => By.LinkText("Report public sector apprenticeship target");
        private By Help = By.LinkText("Help");
        private By Feedback = By.LinkText("Feedback");
        private By Privacy = By.LinkText("Privacy");
        private By Cookies = By.LinkText("Cookies");
        private By BuiltBy = By.LinkText("Education and Skills Funding Agency");
        private By CrownCopyright = By.LinkText("© Crown copyright");

        private By CookiesAcceptButton = By.Id("btn-cookie-accept");
        private By CookiesSettingsButton = By.Id("btn-cookie-settings");

        private By zenHelpWidgetScript1 = By.Id("ze-snippet");
        private By zenHelpWidgetScript2 = By.Id("co-snippet");

        public ApprenticesHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public AddAnApprenitcePage AddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeLink);
            return new AddAnApprenitcePage(_context);
        }

        

        public YourCohortRequestsPage ClickYourCohortsLink()
        {
            formCompletionHelper.ClickElement(YourCohortsLink);
            return new YourCohortRequestsPage(_context);
        }

        public ManageYourApprenticesPage ClickManageYourApprenticesLink()
        {
            formCompletionHelper.ClickElement(ManageYourApprenticesLink);
            return new ManageYourApprenticesPage(_context);
        }

        internal FinancePage GoToFinancePage() => new FinancePage(_context, true);
        public SetpaymentOrderPage ClickSetPaymentOrderLink()
        {
            formCompletionHelper.ClickElement(SetPaymentOrder);
            return new SetpaymentOrderPage(_context);
        }

        public ReportPublicSectorApprenticeshipTargetPage ClickReportPublicSectorApprenticeshipTargetLink()
        {
            formCompletionHelper.ClickElement(ReportPublicSectorApprenticeshipTarget);
            return new ReportPublicSectorApprenticeshipTargetPage(_context);
        }

        public void ValidateFooter()
        {
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(Help), "Validate Help link on the footer of the page");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(Feedback), "Validate Feedback link on the footer of the page");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(Privacy), "Validate Privacy link on the footer of the page");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(Cookies), "Validate Cookies link on the footer of the page");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(BuiltBy), "Validate BuiltBy link on the footer of the page");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(CrownCopyright), "Validate CrownCopyright link on the footer of the page");
        }

        public void ValidateCookiesBanner()
        {
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(CookiesAcceptButton), "Validate accept cookies button on cookies banner");
            Assert.IsTrue(_pageInteractionHelper.IsElementDisplayed(CookiesSettingsButton), "Validate cookie settings button on cookies banner");
        }

        public void ValidateHelpWidget()
        {
            Assert.IsTrue(_pageInteractionHelper.IsElementPresent(zenHelpWidgetScript1), "Validate help widget button in the bottom right");
            Assert.IsTrue(_pageInteractionHelper.IsElementPresent(zenHelpWidgetScript2), "Validate help widget button in the bottom right");
        }

    }
}