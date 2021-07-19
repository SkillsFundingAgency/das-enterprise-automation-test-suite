using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class HelpAndSupportPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Help and support";

        private readonly ScenarioContext _context;
        private By GoBackToTheDashboardButton => By.LinkText("Return to homepage");

        public HelpAndSupportPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage NavigateToOverviewPageWithBackToDashBoardButton()
        {
            formCompletionHelper.Click(GoBackToTheDashboardButton);
            return new ApprenticeHomePage(_context);
        }

        public ApprenticeHomePage NavigateToOverviewPageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeHomePage(_context);
        }
    }
}
