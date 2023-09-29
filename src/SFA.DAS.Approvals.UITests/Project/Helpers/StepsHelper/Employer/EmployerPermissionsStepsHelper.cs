using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class EmployerPermissionsStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderPermissionsSqlDbHelper _providerPermissionsSqlDbHelper;

        public EmployerPermissionsStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerPermissionsSqlDbHelper = context.Get<ProviderPermissionsSqlDbHelper>();
        }

        public void SetAgreementId(HomePage homePage, string orgName)
        {
            var organisationPage = homePage.GoToYourOrganisationsAndAgreementsPage();

            ClickViewAgreementLink(organisationPage, orgName).SetAgreementId();

            organisationPage.GoToHomePage();
        }

        public HomePage SetCreateCohortPermission(string ukprn) => SetProviderPermissions(ukprn, string.Empty, AddApprenticePermissions.Allow, RecruitApprenticePermissions.Allow);

        public HomePage SetRecruitApprenticesPermission(string ukprn, string orgName) => SetProviderPermissions(ukprn, orgName, AddApprenticePermissions.Allow, RecruitApprenticePermissions.Allow);

        private HomePage SetProviderPermissions(string ukprn, string orgName, AddApprenticePermissions addApprenticePermissions, RecruitApprenticePermissions recruitApprenticePermissions)
        {
            return OpenProviderPermissions()
                 .SelectAddANewTrainingProvider()
                 .SearchForATrainingProvider(ukprn)
                 .ConfirmTrainingProvider()
                 .SelectContinueInEmployerTrainingProviderAddedPage()
                 .SelectSetPermissions(orgName)
                 .ClickAddApprentice(addApprenticePermissions)
                 .ClickRecruitApprentice(recruitApprenticePermissions)
                 .ConfirmTrainingProviderPermissions()
                 .GoToHomePage();
        }

        public PermissionsUpdatedPage UnSetCreateCohortPermission()
        {
            return OpenProviderPermissions()
                   .SelectChangePermissions()
                   .ClickAddApprentice(AddApprenticePermissions.DoNotAllow)
                   .ClickRecruitApprentice(RecruitApprenticePermissions.DoNotAllow)
                   .ConfirmYesTrainingProviderPermissions();
        }


        public void RemovePermissisons(ProviderPermissionsConfig providerPermissionConfig)
        {
            RemovePermissionsInSQLDatabase(providerPermissionConfig.Ukprn);

            RemovePermissionsInCosmosDatabase(providerPermissionConfig);
        }


        private void RemovePermissionsInSQLDatabase(string ukprn)
        {
            while (true)
            {
                int accountId = _providerPermissionsSqlDbHelper.GetAccountIdOfAProvider(ukprn);
                if (accountId == 0)
                {
                    break;
                }
                else
                {
                    _providerPermissionsSqlDbHelper.RemoveAllPermissionsOfAProvider(accountId);
                }
            }
        }

        private void RemovePermissionsInCosmosDatabase(ProviderPermissionsConfig providerPermissionConfig) =>
            CosmosActionsPerformerHelper.RemoveProviderPermissionDoc(providerPermissionConfig.PermissionsCosmosUrl, providerPermissionConfig.PermissionsCosmosDBKey, providerPermissionConfig.PermissionsCosmosDatabaseName, providerPermissionConfig.PermissionsCosmosCollectionName, Convert.ToInt64(providerPermissionConfig.Ukprn));


        private YourTrainingProvidersPage OpenProviderPermissions() => new YourTrainingProvidersLinkHomePage(_context).OpenProviderPermissions();

        private YourAgreementsWithTheEducationAndSkillsFundingAgencyPage ClickViewAgreementLink(YourOrganisationsAndAgreementsPage page, string orgName) =>
            string.IsNullOrEmpty(orgName) ? page.ClickViewAgreementLink() : page.ClickViewAgreementLink(orgName);

    }
}