using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected override By ContinueButton => By.XPath("//button[contains(text(), 'Continue')]");
        protected By ReturnToAccountHomeCTA => By.LinkText("Return to account home");
        #endregion

        protected EIBasePage(ScenarioContext context) : base(context)
        {
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
        }
    }
}
