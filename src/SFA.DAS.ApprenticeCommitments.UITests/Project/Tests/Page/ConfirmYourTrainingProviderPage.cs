using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your training provider";

        protected override By ContinueButton => By.CssSelector("#training-provider-confirm");

        public ConfirmYourTrainingProviderPage(ScenarioContext context) : base(context) { }
    }
}
