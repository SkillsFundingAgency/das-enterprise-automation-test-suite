using OpenQA.Selenium;
using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class ConsolidatedSupportBasePage : VerifyBasePage
    {
        protected readonly ConsolidatedSupportConfig config;
        protected readonly ConsolidateSupportDataHelper dataHelper;

        private By CloseButton => By.CssSelector("[data-test-id='close-button']");

        public ConsolidatedSupportBasePage(ScenarioContext context) : base(context)
        {
            config = context.GetConsolidatedSupportConfig<ConsolidatedSupportConfig>();
            dataHelper = context.Get<ConsolidateSupportDataHelper>();
        }

        protected void CloseAllTickets()
        {
            InvokeAction(() =>
            {
                var elements = pageInteractionHelper.FindElements(CloseButton).ToList();
                foreach (var element in elements)
                {
                    element.Click();
                }
            });
        }

        protected void InvokeAction(Action action) => pageInteractionHelper.InvokeAction(action);

        protected T InvokeAction<T>(Func<T> func) => pageInteractionHelper.InvokeAction(func);  
    }
}
