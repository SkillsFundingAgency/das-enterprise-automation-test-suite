using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouHaveAddedYourOrgAndPAYEScheme : RegistrationBasePage
    {
        protected override string PageTitle => "You've added your organisation and PAYE scheme";

        #region Locators
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[role='button']"); 
        private By SaveAndComeBackButton => By.XPath("//button[text()='Save and come back later']");
        #endregion

        public YouHaveAddedYourOrgAndPAYEScheme(ScenarioContext context) : base(context) => VerifyPage();

        public EmployerAccountCreatedPage ContinueToConfirmationPage()
        {
            Continue();
            return new EmployerAccountCreatedPage(context);
        }
            

    }
}
