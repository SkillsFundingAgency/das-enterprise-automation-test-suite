using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_HomePage : BasePage
    {
        protected override string PageTitle => "My applications";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion
        
        private By FindAnApprenticeShip => By.Id("find-apprenticeship-link");

        private By SignOutCss => By.XPath("//a[contains(.,'Sign out')]");

        public FAA_HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchPage ClickFindAnApprenticeshipLink()
        {
            _formCompletionHelper.Click(FindAnApprenticeShip);
            return new FAA_ApprenticeSearchPage(_context);
        }

        public void ClickSignOut()
        {
            _formCompletionHelper.Click(SignOutCss);
        }
    }
}
