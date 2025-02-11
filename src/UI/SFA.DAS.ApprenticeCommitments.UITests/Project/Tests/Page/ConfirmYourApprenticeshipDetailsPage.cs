using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourApprenticeshipDetailsPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm the details of your apprenticeship";

        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourApprenticeshipDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public new ConfirmYourApprenticeshipDetailsPage ClickOnConfirmButton()
        {
            base.ClickOnConfirmButton();
            return this;
        }

        public new ConfirmYourApprenticeshipDetailsPage VerifyErrorSummaryBoxAndErrorFieldText()
        {
            base.VerifyErrorSummaryBoxAndErrorFieldText();
            return this;
        }
    }
}
