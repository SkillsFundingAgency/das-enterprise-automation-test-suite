using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackAlreadySubmittedPage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Feedback already submitted";

        public ProviderFeedbackAlreadySubmittedPage(ScenarioContext context) : base(context, false) 
        {
            tabHelper.OpenInNewTab(UrlConfig.ProviderFeedback_BaseUrl, objectContext.GetUniqueSurveyCode());
            VerifyPage();
        }
    }
}
