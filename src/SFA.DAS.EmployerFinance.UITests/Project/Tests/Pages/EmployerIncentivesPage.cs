using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EmployerIncentivesPage : BasePage
    {
        private readonly PageInteractionHelper _pageInteractionHelper;
        protected override string PageTitle => "Apply for the hire a new apprentice payment";

        public EmployerIncentivesPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void NavigateBackToHomePage() => _pageInteractionHelper.BrowserBack();

    }
}
