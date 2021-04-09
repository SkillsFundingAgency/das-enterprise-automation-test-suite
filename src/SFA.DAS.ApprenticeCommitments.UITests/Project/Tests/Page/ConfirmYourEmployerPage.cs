using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your employer";

        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourEmployerPage(ScenarioContext context) : base(context) =>
            VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetEmployerName().Replace("  ", " "));
    }
}
