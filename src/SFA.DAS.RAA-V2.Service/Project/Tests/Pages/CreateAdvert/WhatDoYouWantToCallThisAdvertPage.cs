using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class WhatDoYouWantToCallThisAdvertPage : BaseVacancyTitlePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        protected override string PageTitle => "What do you want to call this advert?";

        public WhatDoYouWantToCallThisAdvertPage(ScenarioContext context) : base(context) { }
    }
}
