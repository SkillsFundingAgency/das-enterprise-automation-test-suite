using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
   public class ConfirmPartnerShipDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmPartnerShipDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ConfirmAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context); 
        }

        public OrganisationPartnersPage AddAnotherPartner()
        {
            formCompletionHelper.ClickLinkByText("Add another partner");
            return new OrganisationPartnersPage(_context);
        }

    }
}