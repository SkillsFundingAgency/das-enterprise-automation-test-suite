using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class DoesYourOrganisationHaveATeamPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have a team responsible for developing and delivering training?";

        public DoesYourOrganisationHaveATeamPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhoHasTheTeamWorkedPage SelectYes()
        {
            SelectYesAndContinue();
            return new WhoHasTheTeamWorkedPage(context);
        }

        public DoesYourOrganisationHaveSomeonePage SelectNo()
        {
            SelectNoAndContinue();
            return new DoesYourOrganisationHaveSomeonePage(context);
        }
    }
}