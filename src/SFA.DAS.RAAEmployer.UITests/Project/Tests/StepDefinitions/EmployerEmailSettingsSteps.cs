using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEmailSettingsSteps(ScenarioContext context)
    {

        [Then(@"the employer sets the email preferences")]
        public void ThenTheEmployerSetsTheEmailPreferences()
        {
            new ManageYourEmailsEmployerPage(context).SelectAndSaveEmailPreferences().VerifyEmailSettingsConfirmationBanner();
        }
    }
}
