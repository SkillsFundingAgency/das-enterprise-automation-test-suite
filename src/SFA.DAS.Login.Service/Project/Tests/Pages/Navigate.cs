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
        protected readonly TabHelper tabHelper;
        private readonly bool _gotourl;
        private readonly string _url;
        #endregion

        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a, #navigation li a, .das-navigation__link");

        private By MoreLink => By.LinkText("More");

        protected abstract string Linktext { get; }

        protected Navigate(ScenarioContext context, bool navigate) : this(context, navigate, string.Empty) { }
    
        protected Navigate(ScenarioContext context, bool navigate, string url) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();

            if (!(string.IsNullOrEmpty(url))) { tabHelper.GoToUrl(url); }

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