using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class HelpAndSupportPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Help and support";
        private By ReturnToHomePageButton => By.LinkText("Return to homepage");

        public HelpAndSupportPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage NavigateToHomePageWithReturnToHomePageButton()
        {
            formCompletionHelper.Click(ReturnToHomePageButton);
            return new ApprenticeHomePage(_context);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(_context, false);
        }

        public ApprenticeHomePage NavigateToHomePageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeHomePage(_context);
        }
    }
}