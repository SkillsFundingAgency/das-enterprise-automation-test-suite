using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticesHomePage(ScenarioContext context) : InterimApprenticesHomePage(context, false)
    {
        private static By AddAnApprenticeLink => By.LinkText("Add an apprentice");
        private static By ApprenticeRequestsLink => By.LinkText("Apprentice requests");
        private static By ManageYourApprenticesLink => By.LinkText("Manage your apprentices");
        private static By SetPaymentOrder => By.LinkText("Set payment order");
        private static By ReportPublicSectorApprenticeshipTarget => By.LinkText("Report public sector apprenticeship target");
        private static By Help => By.LinkText("Help");
        private static By Feedback => By.LinkText("Feedback");
        private static By Privacy => By.LinkText("Privacy");
        private static By Cookies => By.LinkText("Cookies");
        private static By BuiltBy => By.LinkText("Education and Skills Funding Agency");
        private static By CrownCopyright => By.LinkText("© Crown copyright");
        private static By CookiesAcceptButton => By.Id("btn-cookie-accept");
        private static By CookiesSettingsButton => By.Id("btn-cookie-settings");
        private static By ZenHelpWidgetScript1 => By.Id("ze-snippet");
        private static By ZenHelpWidgetScript2 => By.Id("co-snippet");

        public AddAnApprenitcePage AddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeLink);
            return new AddAnApprenitcePage(context);
        }

        public ApprenticeRequestsPage ClickApprenticeRequestsLink()
        {
            formCompletionHelper.ClickElement(ApprenticeRequestsLink);
            return new ApprenticeRequestsPage(context);
        }

        public ManageYourApprenticesPage ClickManageYourApprenticesLink()
        {
            formCompletionHelper.ClickElement(ManageYourApprenticesLink);
            return new ManageYourApprenticesPage(context);
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

        public ApprenticesHomePage ValidateFooter()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Help), "Validate Help link on the footer of the page");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Feedback), "Validate Feedback link on the footer of the page");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Privacy), "Validate Privacy link on the footer of the page");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(Cookies), "Validate Cookies link on the footer of the page");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(BuiltBy), "Validate BuiltBy link on the footer of the page");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CrownCopyright), "Validate CrownCopyright link on the footer of the page");

            return this;
        }

        public ApprenticesHomePage ValidateCookiesBanner()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CookiesAcceptButton), "Validate accept cookies button on cookies banner");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(CookiesSettingsButton), "Validate cookie settings button on cookies banner");
            return this;
        }

        public ApprenticesHomePage ValidateHelpWidget()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementPresent(ZenHelpWidgetScript1), "Validate help widget button in the bottom right");
            Assert.IsTrue(pageInteractionHelper.IsElementPresent(ZenHelpWidgetScript2), "Validate help widget button in the bottom right");
            return this;
        }
    }
}

