using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouAccountNameHasBeenChangeToPage : RegistrationBasePage
    {
        private  string NewAccountName {get; set;}

        protected override string PageTitle => $"Your account name has been changed to {NewAccountName}";
        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

        public YouAccountNameHasBeenChangeToPage(ScenarioContext context, string newAccountName) : base(context)
        {
            NewAccountName = newAccountName;
            VerifyPage();
        }

        public CreateYourEmployerAccountPage ContinueToCreateYourEmployerAccountPage()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }


    }
}