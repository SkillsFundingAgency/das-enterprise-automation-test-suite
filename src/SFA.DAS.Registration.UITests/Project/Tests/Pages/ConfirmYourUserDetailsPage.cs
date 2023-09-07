using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your user details";
        //protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        public ConfirmYourUserDetailsPage(ScenarioContext context) : base(context) 
        {
            VerifyPage();
        }

        public YouVeSuccessfullyAddedUserDetailsPage ConfirmNameAndContinue()
        {
            Continue();
            return new YouVeSuccessfullyAddedUserDetailsPage(context);
        }
    }
}
