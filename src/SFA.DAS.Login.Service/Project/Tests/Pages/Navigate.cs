using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class Navigate : NavigateBase
    {       
        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a, #navigation li a, .das-navigation__link");

        private By MoreLink => By.LinkText("More");

        protected abstract string Linktext { get; }

        protected Navigate(ScenarioContext context, bool navigate) : this(context, navigate, string.Empty) { }
    
        protected Navigate(ScenarioContext context, bool navigate, string url) : base(context, url) => NavigateTo(navigate);

        protected Navigate(ScenarioContext context, Action navigate, string url) : base(context, url) => NavigateTo(navigate);

        private void NavigateTo(Action navigate) => navigate.Invoke();

        private void NavigateTo(bool navigate)
        {
            if (navigate)
            {
                if (pageInteractionHelper.IsElementDisplayed(MoreLink)) 
                    formCompletionHelper.Click(MoreLink); 

                var link = pageInteractionHelper.GetLink(GlobalNavLink, Linktext);
                
                formCompletionHelper.ClickElement(link);
            }
        }
    }
}