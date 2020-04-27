using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : EmployerHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        protected By AddFavouriteSelector => By.CssSelector(".das-search-result__favourite-button--unchecked");

        protected By RemoveFavouriteSelector => By.CssSelector(".das-search-result__favourite-button--checked");

        protected EmployerBasePage(ScenarioContext context) : base(context) { }

        protected void AddFavourite(Action<string> action, Func<List<IWebElement>, IWebElement> func)
        {
            formCompletionHelper.ClickElement(() =>
            {
                var element = func(pageInteractionHelper.FindElements(AddFavouriteSelector));
                var courseId = element.GetAttribute("value");
                action(courseId);
                return element;
            });
        }

        protected void GoToBasket() => tabHelper.OpenInNewTab(campaignsConfig.CA_BaseUrl, campaignsConfig.BasketView);

        public bool VerifyCount(int count) => (count == 0) ? !pageInteractionHelper.IsElementDisplayed(FavCount) : VerifyPage(FavCount, count.ToString());

    }
}
