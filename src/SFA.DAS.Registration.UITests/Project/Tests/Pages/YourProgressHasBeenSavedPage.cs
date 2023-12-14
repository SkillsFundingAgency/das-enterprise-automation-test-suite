using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourProgressHasBeenSavedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully added";

        private By ContinueCreatingYourAccountButton => By.Id("continue-task-list");
        private By SignOutButton => By.XPath("//button[contains(text(),'Save and come back later')]");

        public YourProgressHasBeenSavedPage(ScenarioContext context) : base(context) { }

        public CreateYourEmployerAccountPage SelectContinueCreatingYourAccount()
        {
            formCompletionHelper.Click(ContinueCreatingYourAccountButton);
            return new CreateYourEmployerAccountPage(context);
        }

        public YouveLoggedOutPage SelectSignOut()
        {
            formCompletionHelper.Click(SignOutButton);
            return new YouveLoggedOutPage(context);
        }
    }
}
