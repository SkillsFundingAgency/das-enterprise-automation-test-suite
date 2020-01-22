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

        private By MainProvider => By.Id("route-1");

        public ChooseProviderRoutePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectApplicationRouteAsMain()
        {
            formCompletionHelper.ClickElement(MainProvider);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
