using System;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.StepDefinitions.DfeUserStepDefs

{
    [Binding]
    public class DfeUserSteps : VerifyBasePage
    {
        public DfeUserSteps(ScenarioContext context) : base(context)
        {
        }

        protected override string PageTitle => "AODP Landing Page";

        [Given(@"Navigate to aodp portal")]
        public void NavigateToBaseUrl()
        {
            tabHelper.GoToUrl(UrlConfig.Aodp_BaseUrl);
            Console.WriteLine("AODP launched  !!!!!!");
        }

    }
}
