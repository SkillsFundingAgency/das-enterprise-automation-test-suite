using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your employer";

        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourEmployerPage(ScenarioContext context) : base(context) =>
            VerifyPage(ConfirmingEntityNamePageHeader, context.Get<ObjectContext>().GetEmployerName().Replace("  ", " "));
    }
}
