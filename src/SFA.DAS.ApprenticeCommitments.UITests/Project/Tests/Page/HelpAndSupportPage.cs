using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class HelpAndSupportPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => "Help and support";
        private static By ReturnToHomePageButton => By.LinkText("Go back to the dashboard");

        public ApprenticeHomePage NavigateToHomePageWithGoBackToTheDashboardButton()
        {
            formCompletionHelper.Click(ReturnToHomePageButton);
            return new ApprenticeHomePage(context, false);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(context, false);
        }

        public FullyConfirmedOverviewPage NavigateToFullyConfirmedOverviewPageWithBackLink()
        {
            NavigateBack();
            return new FullyConfirmedOverviewPage(context);
        }

        public ApprenticeHomePage NavigateToHomePageWithBackLink()
        {
            NavigateBack();
            return new ApprenticeHomePage(context, false);
        }
    }
}