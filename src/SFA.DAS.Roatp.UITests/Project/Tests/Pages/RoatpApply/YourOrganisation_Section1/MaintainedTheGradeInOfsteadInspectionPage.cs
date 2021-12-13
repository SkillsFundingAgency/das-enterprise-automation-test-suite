using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class MaintainedTheGradeInOfsteadInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation maintained the grade it got in its full Ofsted inspection in its short Ofsted inspection?";

        public MaintainedTheGradeInOfsteadInspectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public MaintainedFundingFromAnEducationAgencyPage SelectYesForGradeMaintainedAndContinue()
        {
            SelectYesAndContinue();
            return new MaintainedFundingFromAnEducationAgencyPage(_context);
        }
    }
}
