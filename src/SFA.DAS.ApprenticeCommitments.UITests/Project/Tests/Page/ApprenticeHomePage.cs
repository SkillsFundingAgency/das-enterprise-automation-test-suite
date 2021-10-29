using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}";

        private By ConfirmYourApprenticeshipNowLink => By.XPath("//a[text()='Confirm your apprenticeship now']");
        private By HelpAndSupportSectionLink => By.XPath("//a[text()='help and support section']");

        private By CompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--green");
        private By InCompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--yellow");

        public ApprenticeHomePage(ScenarioContext context, bool verifyConfirmYourApprenticeLink = true) : base(context)
        {
            _context = context;
            VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");
            if (verifyConfirmYourApprenticeLink) VerifyPage(ConfirmYourApprenticeshipNowLink);
        }

        public ChangeYourPersonalDetailsPage GoToChangeYourPersonalDetailsPage()
        {
            VerifyNotificationBanner("There seems to be a problem, we cannot find your apprenticeship.");

            formCompletionHelper.ClickLinkByText("account details");
            
            return new ChangeYourPersonalDetailsPage(_context);
        }

        public void VerifySucessNotification() => VerifyNotificationBanner("You have created an account and we have found your apprenticeship.");

        public ApprenticeOverviewPage NavigateToOverviewPageFromLinkOnTheHomePage()
        {
            formCompletionHelper.Click(ConfirmYourApprenticeshipNowLink);
            return new ApprenticeOverviewPage(_context, false);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPageWithTheLinkOnHomePage()
        {
            formCompletionHelper.Click(HelpAndSupportSectionLink);
            return new HelpAndSupportPage(_context);
        }

        public ApprenticeHomePage VerifyCompleteTag() { VerifyPage(CompleteStatusSelector); return this; }

        public ApprenticeHomePage VerifyInCompleteTag() { VerifyPage(InCompleteStatusSelector); return this; }
    }
}
