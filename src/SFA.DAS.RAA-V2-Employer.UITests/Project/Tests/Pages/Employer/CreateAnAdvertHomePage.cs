using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class CreateAnAdvertHomePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Create an advert";

        protected override bool TakeFullScreenShot => false;

        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public CreateAnAdvertHomePage(ScenarioContext context) : base(context) { }

        public WhatDoYouWantToCallThisAdvertPage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public CreateAnApprenticeshipAdvertPage GoToCreateAnApprenticeshipAdvertPage()
        {
            formCompletionHelper.Click(StartNow);
            return new CreateAnApprenticeshipAdvertPage(context);
        }
    }  
}
