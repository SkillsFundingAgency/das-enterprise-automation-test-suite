using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class OrganisationTypePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us your organisation's type";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationTypePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SoleTraderDOBPage SelectSoleTraderAndContinue()
        {
            SelectRadioOptionByText("Sole trader");
            Continue();
            return new SoleTraderDOBPage(_context);
        }

    }
}


