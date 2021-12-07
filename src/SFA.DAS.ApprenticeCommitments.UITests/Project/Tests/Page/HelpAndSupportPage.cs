using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class HelpAndSupportPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Help and support";
        private By ReturnToHomePageButton => By.LinkText("Go back to the dashboard");

        public HelpAndSupportPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage NavigateToHomePageWithGoBackToTheDashboardButton()
        {
            formCompletionHelper.Click(ReturnToHomePageButton);
            return new ApprenticeHomePage(_context, false);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(_context, false);
        }

        public ApprenticeHomePage NavigateToHomePageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeHomePage(_context, false);
        }
    }
}