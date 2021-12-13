using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
   public class OrganisationPartnersPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation's partner?";

        public OrganisationPartnersPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterOrganisationsDetailsPage SelectOrganisationAndContinue()
        {
            SelectRadioOptionByText("An organisation");
            Continue();
            return new EnterOrganisationsDetailsPage(context);
        }

        public EnterIndividualsDetailsPage SelectIndividualAndContinue()
        {
            SelectRadioOptionByText("An individual");
            Continue();
            return new EnterIndividualsDetailsPage(context);
        }
    }
}
