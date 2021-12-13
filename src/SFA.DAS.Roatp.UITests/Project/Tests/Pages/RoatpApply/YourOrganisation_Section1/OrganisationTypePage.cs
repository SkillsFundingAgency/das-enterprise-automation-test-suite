using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class OrganisationTypePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us your organisation's type";

        public OrganisationTypePage(ScenarioContext context) : base(context) => VerifyPage();

        public SoleTraderDOBPage SelectSoleTraderAndContinue()
        {
            SelectRadioOptionByText("Sole trader");
            Continue();
            return new SoleTraderDOBPage(_context);
        }

        public OrganisationPartnersPage SelectPartnershipAndContinue()
        {
            SelectRadioOptionByText("Partnership");
            Continue();
            return new OrganisationPartnersPage(_context);
        }

        public ConfirmPartnerShipDetailsPage SelectIndividualForPartnershipContinue()
        {
            SelectRadioOptionByText("Partnership");
            Continue();
            return new ConfirmPartnerShipDetailsPage(_context);
        }
    }
}


