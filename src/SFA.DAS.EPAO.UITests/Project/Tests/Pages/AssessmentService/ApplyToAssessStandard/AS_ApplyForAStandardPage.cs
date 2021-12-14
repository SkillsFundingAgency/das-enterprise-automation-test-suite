using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplyForAStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apply for a standard";

        public AS_ApplyForAStandardPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WhatStandardPage Start()
        {
            formCompletionHelper.ClickLinkByText("Start");
            return new AS_WhatStandardPage(context);
        }
    }
}
