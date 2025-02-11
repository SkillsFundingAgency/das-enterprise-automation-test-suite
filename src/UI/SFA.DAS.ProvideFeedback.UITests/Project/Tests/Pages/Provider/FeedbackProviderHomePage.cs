using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider
{
    public class FeedbackProviderHomePage(ScenarioContext context, bool navigate = false)
        : ProviderHomePage(context, navigate)
    {
        public FeedbackOverviewPage SelectYourFeedback()
        {
            formCompletionHelper.Click(YourFeedback);
            return new(context);
        }
    }
}
