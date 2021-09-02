using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class HelpAndSupportPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Help and support";

        private readonly ScenarioContext _context;
        private By ReturnToHomePageButton => By.LinkText("Return to homepage");

        public HelpAndSupportPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeOverviewPage NavigateToOverviewPageWithReturnToHomePageButton()
        {
            formCompletionHelper.Click(ReturnToHomePageButton);
            return new ApprenticeOverviewPage(_context);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(_context);
        }

        public ApprenticeHomePage NavigateToHomePageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeHomePage(_context);
        }
    }
}