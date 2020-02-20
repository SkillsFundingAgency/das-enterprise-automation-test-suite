using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class AlreadyOnRoatpPage : RoatpBasePage
    {
        protected override string PageTitle => "Your organisation is already on the RoATP as an employer provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AlreadyOnRoatpPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ChooseProviderRoutePage SelectYesToChangeProviderRouteAndContinue()
        {
            SelectYesAndContinue();
            return new ChooseProviderRoutePage(_context);
        }
    }
}
