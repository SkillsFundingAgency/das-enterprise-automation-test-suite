using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class HubBasePage : CampaingnsHeaderBasePage
    {
        protected override By PageHeader => By.CssSelector(".fiu-page-header__tag");

        protected By FiuPageHeading => By.CssSelector(".fiu-page-heading__title");

        private By FiuCard => By.CssSelector(".fiu-card");

        private By FiuHeading => By.CssSelector(".fiu-card__heading");

        private By FiuLink => By.CssSelector(".fiu-card__link");

        public HubBasePage(ScenarioContext context) : base(context) { }

        protected void VerifyFiuCards<T>(Func<T> func)
        {
            var fiuCardsHeading = GetFiuCards().Select(x => pageInteractionHelper.GetText(() => x.FindElement(FiuHeading))).ToList();

            foreach (var fiuCardHeading in fiuCardsHeading)
            {
                var fiuCard = GetFiuCards().FirstOrDefault(x => x.Text.Contains(fiuCardHeading));

                formCompletionHelper.ClickElement(() => fiuCard.FindElement(FiuLink));

                VerifyPage(FiuPageHeading, fiuCardHeading);

                VerifyLinks();

                VerifyVideoLinks();

                func.Invoke();
            }
        }

        private List<IWebElement> GetFiuCards() => pageInteractionHelper.FindElements(FiuCard);
    }
}
