using NUnit.Framework;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmpProRelationSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper = new(context);

        private readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

        private (AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions;

        [Given(@"Levy employer grants all permission to a provider")]
        public void LevyEmployerGrantsAllPermissionToAProvider()
        {
            permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

            EPRLogin();

            _employerPermissionsStepsHelper.SetAllProviderPermissions(providerConfig);
        }

        [When(@"the employer changes recruit apprentice permission")]
        public void TheEmployerChangesRecruitApprenticePermission()
        {
            UpdatePermission((AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.AllowConditional));
        }

        [When(@"the provider does not grant any permission")]
        public void WhenTheProviderDoesNotGrantAnyPermission()
        {
            UpdatePermission((AddApprenticePermissions.DoNotAllow, RecruitApprenticePermissions.DoNotAllow));
        }

        [Then(@"an employer has to select at least one permission")]
        public void ThenAnEmployerHasToSelectAtLeastOnePermission()
        {
            EPRLogin();

            new YourTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions()
                .SelectAddATrainingProvider()
                .SearchForATrainingProvider(providerConfig)
                .VerifyDoNotAllowPermissions();
        }

        [Then(@"the provider should be added with the correct permissions")]
        public void TheProviderShouldBeAddedWithTheCorrectPermissions()
        {
            var page = _employerPermissionsStepsHelper.OpenProviderPermissions();

            var providersOnthePage = context.Get<TableRowHelper>().GetTableRows();

            var actual = providersOnthePage.Single(x => x["Training provider"] == providerConfig.Name);

            Assert.Multiple(() =>
            {
                Assert.That(actual["Permission to add apprentice records"], Is.EqualTo(EnumToString.GetStringValue(permissions.AddApprentice)), "Incorrect add apprentice permission trainning provider page");

                Assert.That(actual["Permission to recruit apprentices"], Is.EqualTo(EnumToString.GetStringValue(permissions.RecruitApprentice)), "Incorrect add apprentice permission trainning provider page");
            });

            page.GoToHomePage();
        }

        private void UpdatePermission((AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions)
        {
            this.permissions = permissions;

            _employerPermissionsStepsHelper.UpdateProviderPermission(providerConfig, permissions);
        }

        private void EPRLogin()
        {
            _employerLoginHelper.Login(context.GetUser<EPRLevyUser>(), true);

            new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation();
        }
    }
}

