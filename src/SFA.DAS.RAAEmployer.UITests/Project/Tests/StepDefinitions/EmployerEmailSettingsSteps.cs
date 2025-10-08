using System;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using ManageYourEmailsPage = SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer.ManageYourEmailsPage;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEmailSettingsSteps(ScenarioContext context)
    {

        [Then(@"the employer sets the email preferences")]
        public void ThenTheEmployerSetsTheEmailPreferences()
        {
            new ManageYourEmailsPage(context).SelectAndSaveEmailPreferences().VerifyEmailSettingsConfirmationBanner();
        }
    }
}
