using System;
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
    public class TermsAndConditionsPage : BeforeYouStartPage
    {
        protected override string PageTitle => "Terms and Conditions";

        private By ConfirmAndContinueButton => By.Id("confirm-and-continue");

        public TermsAndConditionsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickConfirmAndContinueButton()
        {
            formCompletionHelper.Click(ConfirmAndButton);
        }

        public TermsAndConditionsPage ClickConfirmAndContinueButton()
        {
            clickConfirmAndContinueButton();
            return new RequireLineManagersApprovalPage(context);
        }

    }
}

        

