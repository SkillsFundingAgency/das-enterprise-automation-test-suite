using NUnit.Framework;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using NewAddApprenticePermissions = SFA.DAS.Registration.UITests.Project.Tests.Pages.AddApprenticePermissions;
using NewRecruitApprenticePermissions = SFA.DAS.Registration.UITests.Project.Tests.Pages.RecruitApprenticePermissions;

using YourTrainingProvidersPage = SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.YourTrainingProvidersPage;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmpProRelationSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        private readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

        private (NewAddApprenticePermissions AddApprentice, NewRecruitApprenticePermissions RecruitApprentice) permissions;

        [Given(@"Levy employer grants all permission to a provider")]
        public void LevyEmployerGrantsAllPermissionToAProvider()
        {
            permissions = (NewAddApprenticePermissions.AllowConditional, NewRecruitApprenticePermissions.Allow);

            EPRLogin();

            new YourTrainingProvidersLinkHomePage(context).OpenProviderPermissions();

            new YourTrainingProvidersPage(context)
                .SelectAddATrainingProvider()
                .SearchForATrainingProvider(providerConfig)
                .AddOrSetPermissions(permissions)
                .VerifyYouHaveAddedNotification();
        }

        [When(@"the employer changes recruit apprentice permission")]
        public void TheEmployerChangesRecruitApprenticePermission()
        {
            UpdatePermission((NewAddApprenticePermissions.AllowConditional, NewRecruitApprenticePermissions.AllowConditional));
        }

        [When(@"the provider does not grant any permission")]
        public void WhenTheProviderDoesNotGrantAnyPermission()
        {
            UpdatePermission((NewAddApprenticePermissions.DoNotAllow, NewRecruitApprenticePermissions.DoNotAllow));
        }

        [Then(@"an employer has to select at least one permission")]
        public void ThenAnEmployerHasToSelectAtLeastOnePermission()
        {
            EPRLogin();

            new YourTrainingProvidersLinkHomePage(context).OpenProviderPermissions();

            new YourTrainingProvidersPage(context)
                .SelectAddATrainingProvider()
                .SearchForATrainingProvider(providerConfig)
                .VerifyDoNotAllowPermissions();
        }

        [Then(@"the provider should be added with the correct permissions")]
        public void TheProviderShouldBeAddedWithTheCorrectPermissions()
        {
            var providersOnthePage = context.Get<TableRowHelper>().GetTableRows();

            var actual = providersOnthePage.Single(x => x["Training provider"] == providerConfig.Name);

            Assert.Multiple(() =>
            {
                Assert.That(actual["Permission to add apprentice records"], Is.EqualTo(EnumToString.GetStringValue(permissions.AddApprentice)), "Incorrect add apprentice permission trainning provider page");

                Assert.That(actual["Permission to recruit apprentices"], Is.EqualTo(EnumToString.GetStringValue(permissions.RecruitApprentice)), "Incorrect add apprentice permission trainning provider page");
            });
        }

        private void UpdatePermission((NewAddApprenticePermissions AddApprentice, NewRecruitApprenticePermissions RecruitApprentice) permissions)
        {
            this.permissions = permissions;

            new YourTrainingProvidersPage(context)
                .SelectChangePermissions(providerConfig.Ukprn)
                .AddOrSetPermissions(permissions)
                .VerifyYouHaveSetPermissionNotification();
        }

        private void EPRLogin()
        {
            _employerLoginHelper.Login(context.GetUser<EPRLevyUser>(), true);

            new DeleteProviderRelationHelper(context).DeleteProviderRelation();
        }
    }
}

