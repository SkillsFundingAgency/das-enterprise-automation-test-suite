using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    class CreateAnAdvertHomePage : RAAV2CSSBasePage
    {

        protected override string PageTitle => "Create an advert";

        #region Helpers and Context      
        private readonly ScenarioContext _context;
        #endregion
        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");
     
        public CreateAnAdvertHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public WhatDoYouWantToCallThisAdvertPage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new WhatDoYouWantToCallThisAdvertPage(_context);
        }
    }  
}
