using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderPermissions
    {
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderPermissionsDatahelper _providerPermissionsDatahelper;
        private readonly ProviderPermissionsConfig _config;

        public ProviderPermissions(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<ProviderPermissionsConfig>();
            _providerPermissionsDatahelper = context.Get<ProviderPermissionsDatahelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }


        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            _loginHelper.Login(_context.GetUser<ProviderPermissionLevyUser>(), true);

           // RemovePermissionsInSQLDatabase();
           // RemovePermissionsInCosmosDatabase();

            new TrainingProviderPermissionsHomePage(_context)
               .OpenProviderPermissions()
               .SelectAddANewTrainingProvider()
               .SearchForATrainingProvider()
               .ConfirmTrainingProvider()
               .SelectContinueInEmployerTrainingProviderAddedPage()
               .SetCreateCohortPermissions()
               .ConfirmTrainingProviderPermissions()
               .GoToHomePage();
        }

        [When(@"Employer revoke create cohort permission to a provider")]
        public void WhenEmployerRevokeCreateCohortPermissionToAProvider()
        {
            _employerStepsHelper.GotoEmployerHomePage();

            new TrainingProviderPermissionsHomePage(_context)
                .OpenProviderPermissions()
                .SelectSetPermissions()
                .UnSetCreateCohortPermissions()
                .ConfirmTrainingProviderPermissions()
                .GoToHomePage();
        }

        [Then(@"Provider can view Create Cohort link")]
        public void ThenProviderCanViewCreateCohortLink()
        {
            Assert.IsTrue(CreateCohortPermissionLinkIsDisplayed());
        }

        [Then(@"Provider cannot view Create Cohort link")]
        public void ThenProviderCannotViewCreateCohortLink()
        {
            Assert.IsFalse(CreateCohortPermissionLinkIsDisplayed());
        }

        private bool CreateCohortPermissionLinkIsDisplayed()
        {
            return _providerStepsHelper.GoToProviderHomePage().CreateCohortPermissionLinkIsDisplayed();
        }

        private void RemovePermissionsInSQLDatabase()
        {
            while (true)
            {
                int accountId = _providerPermissionsDatahelper.GetAccountIdOfAProvider();
                if (accountId == 0)
                {
                    break;
                }
                else
                {
                    _providerPermissionsDatahelper.RemoveAllPermissionsOfAProvider(accountId);
                }
            }
        }

        private void RemovePermissionsInCosmosDatabase()
        {
            CosmosActionsPerformerHelper.RemoveDoc(_config.AP_PrelDbCosmosUri, _config.AP_PrelDbAuthKey, _config.AP_PrelDbDatabaseName, _config.AP_PrelDbCollectionName, "ukprn", _config.AP_ProviderPermissionUkprn);
        }
    }
}
