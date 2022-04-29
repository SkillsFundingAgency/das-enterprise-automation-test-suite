using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
   public class EmployerDashboardPage : ProvideFeedbackBasePage 
    {
        protected override string PageTitle => "PRO LIMITED";

        public EmployerDashboardPage(ScenarioContext context) : base(context) { }

        public SelectTrainingProviderPage ClickFeedbackLink()
        {
            formCompletionHelper.ClickLinkByText("Feedback on training providers");
            return new SelectTrainingProviderPage(context);
        }
    }
}
