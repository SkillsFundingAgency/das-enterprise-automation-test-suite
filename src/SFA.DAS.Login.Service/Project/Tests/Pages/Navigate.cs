using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class Navigate : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly TableRowHelper tableRowHelper;
        #endregion

        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a, #navigation li a, .das-navigation__link");

        private By MoreLink => By.LinkText("More");

        protected abstract string Linktext { get; }

        protected Navigate(ScenarioContext context, bool navigate) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            NavigateTo(navigate);
        }

        protected void NavigateTo(bool navigate)
        {
            if (navigate)
            {
                OpenSubMenu();
         
                var link = pageInteractionHelper.GetLink(GlobalNavLink, Linktext);
                
                formCompletionHelper.ClickElement(link);
            }
        }

        protected void OpenSubMenu()
        {
            if (Linktext == "PAYE schemes" && pageInteractionHelper.IsElementDisplayed(MoreLink)) { formCompletionHelper.Click(MoreLink); }
                
        }
    }
}