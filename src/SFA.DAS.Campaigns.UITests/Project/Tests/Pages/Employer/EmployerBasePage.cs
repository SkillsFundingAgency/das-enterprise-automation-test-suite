using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : EmployerHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        protected By Favourite => By.CssSelector(".das-search-result__favourite-button--unchecked");

        public EmployerBasePage(ScenarioContext context) : base(context) { }

        protected void AddFavourite(Action<string> action)
        {
            formCompletionHelper.ClickElement(() =>
            {
                var element = campaignsDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Favourite));
                var courseId = element.GetAttribute("value");
                action(courseId);
                return element;
            });
        }

        protected void GoToBasket() => formCompletionHelper.ClickElement(Basket);
    }
}
