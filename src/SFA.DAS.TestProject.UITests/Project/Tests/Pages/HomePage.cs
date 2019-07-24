
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    internal sealed class HomePage : BasePage
    {
        #region Constants
        private const string PageTitle = "";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public HomePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        internal bool IsPageMatching()
        {
            return VerifyPage(PageTitle);
        }
    }
}