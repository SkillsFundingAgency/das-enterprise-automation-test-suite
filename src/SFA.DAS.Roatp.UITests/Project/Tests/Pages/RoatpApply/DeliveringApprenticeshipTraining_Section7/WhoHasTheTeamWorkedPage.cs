using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class WhoHasTheTeamWorkedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who has the team worked with to develop and deliver training?";

        public WhoHasTheTeamWorkedPage(ScenarioContext context) : base(context) => VerifyPage();

        public HowHasTheTeamWorkedWithBothPage SelectBothOptions()
        {
            SelectRadioOptionByText("Both other organisations and employers");
            Continue();
            return new HowHasTheTeamWorkedWithBothPage(_context);
        }

        public HowHasTheTeamWorkedWithOrganisationsPage SelectOrganisations()
        {
            SelectRadioOptionByText("Other Organisations");
            Continue();
            return new HowHasTheTeamWorkedWithOrganisationsPage(_context);
        }
    }
}