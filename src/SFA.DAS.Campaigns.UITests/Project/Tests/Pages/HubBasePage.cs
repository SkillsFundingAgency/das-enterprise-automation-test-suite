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

        protected By SubPageHeader => By.CssSelector(".govuk-heading-xl");


        private By FiuCard => By.CssSelector(".fiu-card");

        private By FiuHeading => By.CssSelector(".fiu-card__heading");

        private By FiuLink => By.CssSelector(".fiu-card__link");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HubBasePage(ScenarioContext context) : base(context) => _context = context;

        protected T VerifyFiuCards<T>(Func<T> func)
        {
            T result = default;

            var fiuCardsHeading = GetFiuCards().Select(x => pageInteractionHelper.GetText(() => x.FindElement(FiuHeading))).ToList();

            foreach (var fiuCardHeading in fiuCardsHeading)
            {
                var fiuCard = GetFiuCards().FirstOrDefault(x => x.Text.Contains(fiuCardHeading));

                new CampaingnsDynamicFiuPage(_context, () => formCompletionHelper.ClickElement(() => fiuCard.FindElement(FiuLink)), fiuCardHeading);

                result = func.Invoke();
            }
            return result;
        }

        private List<IWebElement> GetFiuCards() => pageInteractionHelper.FindElements(FiuCard);
    }
}
