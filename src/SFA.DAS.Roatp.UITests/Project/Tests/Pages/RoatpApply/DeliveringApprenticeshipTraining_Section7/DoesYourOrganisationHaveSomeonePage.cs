using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class DoesYourOrganisationHaveSomeonePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have someone responsible for developing and delivering training?";

        public DoesYourOrganisationHaveSomeonePage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectNo()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(context);
        }

        public WhoHasThePersonWorkedPage SelectYes()
        {
            SelectYesAndContinue();
            return new WhoHasThePersonWorkedPage(context);
        }
    }
}
