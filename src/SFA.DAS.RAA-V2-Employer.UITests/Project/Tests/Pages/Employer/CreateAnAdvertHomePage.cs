using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class CreateAnAdvertHomePage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Create an advert";

        protected override bool TakeFullScreenShot => false;

        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public WhatDoYouWantToCallThisAdvertPage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage GoToCreateAnApprenticeshipAdvertPage()
        {
            formCompletionHelper.Click(StartNow);
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
