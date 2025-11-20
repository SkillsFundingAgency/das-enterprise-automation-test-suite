using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class SummaryOfTheApprenticeshipPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Summary of the apprenticeship";

        private static By ShortDescIframe => By.Id("ShortDescription_ifr");
        private static By IframeBody => By.CssSelector(".mce-content-body");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public WhatWillTheApprenticeDoAtWorkPage EnterShortDescription()
        {
            javaScriptHelper.SwitchFrameAndEnterText(ShortDescIframe, IframeBody, RAA.DataGenerator.RAADataHelper.RandomAlphabeticString(60));
            Continue();
            return new WhatWillTheApprenticeDoAtWorkPage(context);
        }
    }
}
