using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Confirm your training provider";

        protected override By ContinueButton => By.CssSelector("#training-provider-confirm");

        public ConfirmYourTrainingProviderPage(ScenarioContext context) : base(context) 
        {
            VerifyPage(ProviderNamePageHeader, context.Get<ObjectContext>().GetProviderName());
        }
    }
}
