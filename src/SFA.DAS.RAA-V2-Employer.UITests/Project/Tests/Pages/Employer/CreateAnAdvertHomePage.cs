using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    class CreateAnAdvertHomePage : RAAV2CSSBasePage
    {
  
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Create an advert";
        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public CreateAnAdvertHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public VacancyTitlePage ClickStartNow()
        {
            formCompletionHelper.Click(StartNow);
            return new VacancyTitlePage(_context);
        }
    }  
}
