using OpenQA.Selenium;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public  class YouVeAcceptedYourEmployerAgreement : RegistrationBasePage
    {
        protected override string PageTitle => "You've accepted your employer agreement";
        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");
        public YouVeAcceptedYourEmployerAgreement(ScenarioContext context) : base(context) => VerifyPage();

        public CreateYourEmployerAccountPage SelectContinueToCreateYourEmployerAccount()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }


    }
}
