using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
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