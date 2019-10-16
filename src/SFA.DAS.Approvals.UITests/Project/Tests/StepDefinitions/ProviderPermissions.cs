using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
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
        private readonly EmployerPortalLoginHelper _employerLoginHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderPermissionsDatahelper _providerPermissionsDatahelper;
        private readonly ProviderPermissionsConfig _providerPermissionConfig;
        private ProviderLogin _providerLogin;
        private readonly ApprovalsConfig _approvalsConfig;

        public ProviderPermissions(ScenarioContext context)
        {
            _context = context;
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            _providerPermissionsDatahelper = context.Get<ProviderPermissionsDatahelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _employerLoginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Then(@"the Employer can set create cohort and recruitment permissions")]
        public void ThenTheEmployerCanSetCreateCohortAndRecruitmentPermissions()
        {
            _employerPermissionsStepsHelper.SetCreateCohortAndRecruitmentPermission(_providerPermissionConfig.AP_ProviderUkprn);

            _providerLogin = new ProviderLogin { Username = _providerPermissionConfig.AP_ProviderUserId, Password = _providerPermissionConfig.AP_ProviderPassword, Ukprn = _providerPermissionConfig.AP_ProviderUkprn };
        }

        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            _employerLoginHelper.Login(_context.GetUser<ProviderPermissionLevyUser>(), true);

             RemovePermissionsInSQLDatabase();

             RemovePermissionsInCosmosDatabase();

            _employerPermissionsStepsHelper.SetCreateCohortPermission(_approvalsConfig.AP_ProviderUkprn);
        }

        [When(@"Employer revoke create cohort permission to a provider")]
        public void WhenEmployerRevokeCreateCohortPermissionToAProvider()
        {
            _employerStepsHelper.GotoEmployerHomePage();

            _employerPermissionsStepsHelper.UnSetCreateCohortPermission();
        }

        [Then(@"Provider can view Create Cohort link")]
        public void ThenProviderCanViewCreateCohortLink()
        {
            Assert.IsTrue(CreateCohortPermissionLinkIsDisplayed(), "Create Cohort link is not visible");
        }

        [Then(@"Provider cannot view Create Cohort link")]
        public void ThenProviderCannotViewCreateCohortLink()
        {
            Assert.IsFalse(CreateCohortPermissionLinkIsDisplayed(), "Create Cohort link is visible");
        }

        private bool CreateCohortPermissionLinkIsDisplayed()
        {
            return _providerStepsHelper.GoToProviderHomePage(_providerLogin).CreateCohortPermissionLinkIsDisplayed();
        }

        private void RemovePermissionsInSQLDatabase()
        {
            while (true)
            {
                int accountId = _providerPermissionsDatahelper.GetAccountIdOfAProvider(_approvalsConfig.AP_ProviderUkprn);
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
            CosmosActionsPerformerHelper.RemoveDoc(_providerPermissionConfig.PermissionsCosmosUrl, _providerPermissionConfig.PermissionsCosmosDBKey, _providerPermissionConfig.PermissionsCosmosDatabaseName, _providerPermissionConfig.PermissionsCosmosCollectionName, "ukprn", _approvalsConfig.AP_ProviderUkprn);
        }
    }
}
