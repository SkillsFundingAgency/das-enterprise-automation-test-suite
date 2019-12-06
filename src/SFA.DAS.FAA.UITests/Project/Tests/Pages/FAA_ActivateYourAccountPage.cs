using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage : BasePage
    {
        protected override string PageTitle => "Activate your account";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FAA_ActivateYourAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}