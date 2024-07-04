using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WhatWillTheApprenticeDoAtWorkPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "What will the apprentice do at work?";

        private static By ApprenticeWorkSelector => By.Id("VacancyDescription_ifr");
        private static By IframeBody => By.CssSelector(".mce-content-body ");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public DescriptionPage EnterShortDescriptionOfWhatApprenticeWillDo()
        {
            javaScriptHelper.SwitchFrameAndEnterText(ApprenticeWorkSelector, IframeBody, rAAV2DataHelper.VacancyShortDescription);
            Continue();
            return new DescriptionPage(context);
        }
    }
}
