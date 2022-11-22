using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class HubBasePage : CampaingnsHeaderBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By PageHeaderTag => By.CssSelector(".fiu-page-header__tag");

        protected By SubPageHeader => By.CssSelector(".govuk-heading-xl");

        private static By FiuCard => By.CssSelector(".fiu-card");

        private static By FiuHeading => By.CssSelector(".fiu-card__heading");

        private static By FiuLink => By.CssSelector(".fiu-card__link");

        public HubBasePage(ScenarioContext context) : base(context)  { }

        protected T VerifyFiuCards<T>(Func<T> func)
        {
            List<Exception> exceptions = new();

            T result = default;

            var fiuCardsHeading = GetFiuCards().Select(x => pageInteractionHelper.GetText(() => x.FindElement(FiuHeading))).ToList();

            foreach (var fiuCardHeading in fiuCardsHeading)
            {
                try
                {
                    var fiuCard = GetFiuCards().FirstOrDefault(x => x.Text.Contains(fiuCardHeading));

                    formCompletionHelper.ClickElement(() => fiuCard.FindElement(FiuLink));

                    _ = new CampaingnsDynamicFiuPage(context, fiuCardHeading);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
                finally
                {
                    result = func.Invoke();
                }
            }

            if (exceptions.Count > 0) throw new Exception(exceptions.ExceptionToString());

            return result;
        }

        private List<IWebElement> GetFiuCards() => pageInteractionHelper.FindElements(FiuCard);
    }
}
