using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
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
        private ProviderHomePage _providerHomePage;

        public ProviderPermissions(ScenarioContext context)
        {
            _context = context;
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _providerPermissionsDatahelper = context.Get<ProviderPermissionsDatahelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _employerLoginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }
   
        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            RemovePermissionsInSQLDatabase();

            RemovePermissionsInCosmosDatabase();

            var homePage = _employerLoginHelper.Login(_context.GetUser<ProviderPermissionLevyUser>(), true);

            var organisationPage = homePage.GoToYourOrganisationsAndAgreementsPage();

            organisationPage.SetAgreementId();

            organisationPage.GoToHomePage();
           
            _employerPermissionsStepsHelper.SetCreateCohortPermission(_providerPermissionConfig.AP_ProviderUkprn);

            _providerLogin = ProviderLogin(_providerPermissionConfig.AP_ProviderUserId, _providerPermissionConfig.AP_ProviderPassword, _providerPermissionConfig.AP_ProviderUkprn);
        }

        [When(@"Employer revoke create cohort permission to a provider")]
        public void WhenEmployerRevokeCreateCohortPermissionToAProvider()
        {
            _employerStepsHelper.GotoEmployerHomePage();

            _employerPermissionsStepsHelper.UnSetCreateCohortPermission();
        }

        [Then(@"Provider can Create Cohort")]
        public void ThenProviderCanCreateCohort()
        {
            var linkDisplayed = CreateCohortPermissionLinkIsDisplayed();

            if (linkDisplayed)
            {
                Assert.IsTrue(CanChooseAnEmployer(), "Create Cohort link is not visible");
            }
            else
            {
                Assert.IsTrue(linkDisplayed, "Create Cohort link is not visible");
            }

            _providerHomePage.SignsOut();
        }

        [Then(@"Provider cannot Create Cohort")]
        public void ThenProviderCannotCreateCohort()
        {
            var linkDisplayed = CreateCohortPermissionLinkIsDisplayed();

            if (linkDisplayed)
            {
                Assert.IsFalse(linkDisplayed, "Create Cohort link is visible");
            }
            else
            {
                Assert.IsFalse(linkDisplayed, "Create Cohort link is visible");
            }
        }

        private bool CanChooseAnEmployer()
        {
            return _providerHomePage.GotoChooseAnEmployerNonLevyPage().CanChooseAnEmployer();
        }

        private bool CreateCohortPermissionLinkIsDisplayed()
        {
            _providerHomePage = _providerStepsHelper.GoToProviderHomePage(_providerLogin);

            return _providerHomePage.CreateCohortPermissionLinkIsDisplayed();
        }

        private void RemovePermissionsInSQLDatabase()
        {
            while (true)
            {
                int accountId = _providerPermissionsDatahelper.GetAccountIdOfAProvider(_providerPermissionConfig.AP_ProviderUkprn);
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
            CosmosActionsPerformerHelper.RemoveProviderPermissionDoc(_providerPermissionConfig.PermissionsCosmosUrl, _providerPermissionConfig.PermissionsCosmosDBKey, _providerPermissionConfig.PermissionsCosmosDatabaseName, _providerPermissionConfig.PermissionsCosmosCollectionName, Convert.ToInt64(_providerPermissionConfig.AP_ProviderUkprn));
        }

        private ProviderLogin ProviderLogin(string usename, string password, string ukprn)
        {
            return new ProviderLogin { Username = usename, Password = password, Ukprn = ukprn };
        }
    }
}
