using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage : BasePage
    {
        protected readonly IFrameHelper frameHelper;
        protected readonly TabHelper tabHelper;
        protected readonly ConsolidatedSupportConfig config;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly ConsolidateSupportDataHelper dataHelper;

        private By CloseButton => By.CssSelector("[data-test-id='close-button']");

        public ConsolidatedSupportBasePage(ScenarioContext context) : base(context)
        {
            tabHelper = context.Get<TabHelper>();
            frameHelper = context.Get<IFrameHelper>();
            config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            dataHelper = context.Get<ConsolidateSupportDataHelper>();
        }

        protected void CloseAllTickets()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                var elements = pageInteractionHelper.FindElements(CloseButton).ToList();
                foreach (var element in elements)
                {
                    element.Click();
                }
            });
        }
    }
}
