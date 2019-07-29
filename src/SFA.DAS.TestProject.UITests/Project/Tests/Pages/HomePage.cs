
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    internal sealed class HomePage : TestProjectBasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        protected override string PageTitle => "";

        public HomePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }
    }
}