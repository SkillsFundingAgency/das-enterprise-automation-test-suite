using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm the details of your apprenticeship";
        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourApprenticeshipDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
