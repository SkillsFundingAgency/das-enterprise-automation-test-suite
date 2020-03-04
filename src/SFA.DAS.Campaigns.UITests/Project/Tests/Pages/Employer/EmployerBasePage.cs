using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : EmployerHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        protected By Favourite => By.CssSelector(".das-search-result__favourite-button--unchecked");

        public EmployerBasePage(ScenarioContext context) : base(context) { }

        protected void AddFavourite() => formCompletionHelper.ClickElement(() => campaignsDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Favourite)));

        protected void GoToBasket() => formCompletionHelper.ClickElement(Basket);
    }
}
