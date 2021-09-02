using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}";
        private By CMADLink => By.XPath("//h2[text()='Confirm my apprenticeship details']");
        private By HelpAndSupportLink => By.XPath("//h2[text()='Help and support']");

        public ApprenticeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");
        }

        public ApprenticeOverviewPage NavigateToOverviewPageFromLinkOnTheHomePage()
        {
            formCompletionHelper.Click(CMADLink);
            return new ApprenticeOverviewPage(_context);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPageWithTheLinkOnHomePage()
        {
            formCompletionHelper.Click(HelpAndSupportLink);
            return new HelpAndSupportPage(_context);
        }
    }
}
