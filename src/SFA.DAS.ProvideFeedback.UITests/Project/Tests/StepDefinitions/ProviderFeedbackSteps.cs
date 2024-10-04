using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderFeedbackSteps(ScenarioContext context)
    {
        [Given(@"The provider logs in to the provider portal")]
        public void GivenTheProviderLogsInToTheProviderPortal()
        {
            var homePage = GoToProviderHomePage(false);
            var feedbackOverview = homePage.SelectYourFeedback();
        }

        public FeedbackProviderHomePage GoToProviderHomePage(bool newTab)
        {
            var providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            providerCommonStepsHelper.GoToProviderHomePage(false);
            return new FeedbackProviderHomePage(context, false);
        }

    }
}
