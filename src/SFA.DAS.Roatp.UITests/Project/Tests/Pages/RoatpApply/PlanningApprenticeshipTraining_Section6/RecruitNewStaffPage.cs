using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class RecruitNewStaffPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Will your organisation recruit new staff to deliver training against these forecasts?";

        public RecruitNewStaffPage(ScenarioContext context) : base(context) => VerifyPage();

        public TypicalRatioOfStaffPage SelectYesRecruitNewStaffAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TypicalRatioOfStaffPage(context);
        }
    }
}
