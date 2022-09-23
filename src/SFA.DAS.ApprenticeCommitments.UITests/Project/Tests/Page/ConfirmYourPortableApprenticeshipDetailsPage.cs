using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourPortableApprenticeshipDetailsPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm the details of your portable flexi-job apprenticeship";
        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourPortableApprenticeshipDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
