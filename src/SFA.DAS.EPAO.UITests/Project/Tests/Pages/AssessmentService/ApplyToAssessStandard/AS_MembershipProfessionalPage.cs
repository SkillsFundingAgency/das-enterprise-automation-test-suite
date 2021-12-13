using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_MembershipProfessionalPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Give details of membership of professional organisations";

        public AS_MembershipProfessionalPage(ScenarioContext context) : base(context) { }

        public AS_HowManyAssessorsPage EnterMembershipDetails()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_HowManyAssessorsPage(context);
        }
    }
}
