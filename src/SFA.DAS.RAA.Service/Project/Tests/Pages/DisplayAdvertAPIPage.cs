using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class DisplayAdvertAPIPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Display advert API";
        protected override By PageHeader => By.ClassName("sl-text-5xl");
        protected override bool TakeFullScreenShot => false;
        private readonly By TitleTagsLocator = By.CssSelector("[title]");

        private List<string> expectedTitles = new List<string>
        {
            "AccountLegalEntities",
            "ReferenceData",
            "Vacancy"
        };

        public DisplayAdvertAPIPage VerifyEndpointTitles()
        {
            var titleElements = pageInteractionHelper.FindElements(TitleTagsLocator);
            if (titleElements.Count == 0)
            {
                throw new Exception("No title tags found on the page.");
            }

            var actualTitles = titleElements.Select(element => element.GetAttribute("title")).ToList();

            if (!expectedTitles.All(expectedTitle => actualTitles.Contains(expectedTitle)))
            {
                throw new Exception($"Expected titles: {string.Join(", ", expectedTitles)} do not match actual titles: {string.Join(", ", actualTitles)}");
            }

            return this;
        }

    }
}
