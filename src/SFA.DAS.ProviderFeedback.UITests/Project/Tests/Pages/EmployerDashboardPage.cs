using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
   public class EmployerDashboardPage : ProvideFeedbackBasePage 
    {
        protected override string PageTitle => "PRO LIMITED";
        private readonly TabHelper _tabHelper;

        public EmployerDashboardPage(ScenarioContext context) : base(context) { _tabHelper = context.Get<TabHelper>(); }

        public SelectTrainingProviderPage ClickFeedbackLink()
        {
            formCompletionHelper.ClickLinkByText("Feedback on training providers");
            return new SelectTrainingProviderPage(context);
        }

        public ProvideFeedbackHomePage OpenFeedbackLinkWithSurveyCode()
        {
            GoToUrl("https://pp-feedback.apprenticeships.education.gov.uk/CA517E3B-243C-4ACA-8DBC-5CADAAED4271");
            return new ProvideFeedbackHomePage(context);
        }

        protected void GoToUrl(string url) => _tabHelper.GoToUrl(url);
    }
}
