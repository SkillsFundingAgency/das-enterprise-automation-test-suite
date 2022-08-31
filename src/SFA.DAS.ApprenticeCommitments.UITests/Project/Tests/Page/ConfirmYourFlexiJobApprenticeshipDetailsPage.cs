using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourFlexiJobApprenticeshipDetailsPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm the details of your flexi-job agency apprenticeship";
        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourFlexiJobApprenticeshipDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public new ConfirmYourFlexiJobApprenticeshipDetailsPage ClickOnConfirmButton()
        {
            base.ClickOnConfirmButton();
            return this;
        }

        public new ConfirmYourFlexiJobApprenticeshipDetailsPage VerifyErrorSummaryBoxAndErrorFieldText()
        {
            base.VerifyErrorSummaryBoxAndErrorFieldText();
            return this;
        }
    }
}
