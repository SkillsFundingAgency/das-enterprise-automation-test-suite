using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : EmployerHubPage
    {
        //protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By AddFavouriteSelector => By.CssSelector(".fiu-favourite-bar__link ");

        protected By RemoveFavouriteSelector => By.CssSelector(". fiu-favourite-bar__link--active");

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

        protected void GoToBasket() => tabHelper.OpenInNewTab(UrlConfig.CA_BaseUrl, CampaignsConfig.BasketViewPath);

        public bool VerifyCount(int count) => (count == 0) ? !pageInteractionHelper.IsElementDisplayed(FavCount) : VerifyPage(FavCount, count.ToString());
    }
}
