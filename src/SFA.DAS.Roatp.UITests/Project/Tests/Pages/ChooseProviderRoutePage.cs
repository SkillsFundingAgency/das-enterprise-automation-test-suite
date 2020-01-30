using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{

    public class ChooseProviderRoutePage : RoatpBasePage
    {
        protected override string PageTitle => "Choose your organisation's provider route";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChooseProviderRoutePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectApplicationRouteAsMain()
        {
            SelectRadioOptionByForAttribute("route-1");
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public LevyPayingEmployerPage SelectApplicationRouteAsEmployer()
        {
            SelectRadioOptionByForAttribute("route-2");
            Continue();
            return new LevyPayingEmployerPage(_context);
        }

        public ApplicationOverviewPage SelectApplicationRouteAsSupporting()
        {
            SelectRadioOptionByForAttribute("route-3");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
