using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class SummaryOfTheApprenticeshipPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Summary of the apprenticeship";

        private static By ShortDescSelector => By.CssSelector("textarea#ShortDescription");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public WhatWillTheApprenticeDoAtWorkPage EnterShortDescription()
        {
            formCompletionHelper.EnterText(ShortDescSelector, RAA.DataGenerator.RAAV2DataHelper.RandomAlphabeticString(60));
            Continue();
            return new WhatWillTheApprenticeDoAtWorkPage(context);
        }
    }
}
