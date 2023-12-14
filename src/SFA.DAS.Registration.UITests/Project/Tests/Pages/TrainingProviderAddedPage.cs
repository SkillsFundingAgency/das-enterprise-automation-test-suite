using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class TrainingProviderAddedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully added";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public TrainingProviderAddedPage(ScenarioContext context) : base(context)  { }

        public YourTrainingProvidersPage SelectContinueInEmployerTrainingProviderAddedPage()
        { 
            Continue();
            return new YourTrainingProvidersPage(context);
        }
    }
}