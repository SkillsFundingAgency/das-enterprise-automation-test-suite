using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderAddedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "You've successfully added";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public YourTrainingProvidersPage SelectContinueInEmployerTrainingProviderAddedPage()
        {
            Continue();
            return new YourTrainingProvidersPage(context);
        }
    }
}