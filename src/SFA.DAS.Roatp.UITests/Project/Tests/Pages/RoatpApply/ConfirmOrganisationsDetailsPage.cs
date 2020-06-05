using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ConfirmOrganisationsDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your organisation's details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmOrganisationsDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ChooseProviderRoutePage ClickConfirmAndContinue()
        {
            Continue();
            return new ChooseProviderRoutePage(_context);
        }

        public AlreadyOnRoatpPage ClickConfirmAndContinueForProviderOnRoatp()
        {
            Continue();
            return new AlreadyOnRoatpPage(_context);
        }
    }
}
