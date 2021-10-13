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

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");
        }

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

        public void VerifyCompleteTag() => VerifyPage(CompleteStatusSelector);

        public void VerifyInCompleteTag() => VerifyPage(InCompleteStatusSelector);
    }
}
