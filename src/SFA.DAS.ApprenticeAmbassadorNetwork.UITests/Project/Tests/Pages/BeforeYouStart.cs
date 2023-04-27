using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class BeforeYouStartPage : SignInPage
    {
        protected override string PageTitle => "Before you start";

        private By StartButton => By.Id("start-now");

        public BeforeYouStartPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickStartButton() 
        {
            formCompletionHelper.Click(StartButton);
        }

        public BeforeYouStartPage ClickStartButton()
        {
            clickStartButton();
            return new TermsAndConditionsPage(context);
        }
    }
}