using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ChangeRoutePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Changing your provider route";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChangeRoutePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ChooseProviderRoutePage SelectYesToChangeRouteAndContinue()
        {
            SelectYesAndContinue();
            return new ChooseProviderRoutePage(_context);
        }

        public ApplicationOverviewPage SelectNoToChangeRouteAndContinue()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}