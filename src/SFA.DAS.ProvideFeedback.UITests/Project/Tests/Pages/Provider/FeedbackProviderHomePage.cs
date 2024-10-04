using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider
{
    public class FeedbackProviderHomePage(ScenarioContext context, bool navigate = false)
        : ProviderHomePage(context, navigate)
    {
        public FeedbackOverviewPage SelectYourFeedback()
        {
            formCompletionHelper.Click(YourFeedback);
            return new(context, false);
        }
    }

    public class FeedbackOverviewPage(ScenarioContext context, bool navigate = false)
    {

    }
}
