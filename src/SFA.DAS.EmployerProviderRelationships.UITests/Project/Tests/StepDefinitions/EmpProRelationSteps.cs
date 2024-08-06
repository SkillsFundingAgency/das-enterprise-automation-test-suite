using NUnit.Framework;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using NewAddApprenticePermissions = SFA.DAS.Registration.UITests.Project.Tests.Pages.AddApprenticePermissions;
using NewRecruitApprenticePermissions = SFA.DAS.Registration.UITests.Project.Tests.Pages.RecruitApprenticePermissions;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmpProRelationSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        private readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

        private (NewAddApprenticePermissions AddApprentice, NewRecruitApprenticePermissions RecruitApprentice) permissions;

        private YourTrainingProvidersPage _yourTrainingProvidersPage;

        [Given(@"Levy employer grants all permission to a provider")]
        public void LevyEmployerGrantsAllPermissionToAProvider()
        {
            permissions = (NewAddApprenticePermissions.AllowConditional, NewRecruitApprenticePermissions.Allow);

            EPRLogin();

            context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerProviderRelationships_BaseUrl(_objectContext.GetHashedAccountId()));

            _yourTrainingProvidersPage = new YourTrainingProvidersPage(context)
                .SelectAddATrainingProvider()
                .SearchForATrainingProvider(providerConfig)
                .SetPermissions(permissions)
                .VerifyYouHaveAddedNotification();
        }

        [When(@"the employer changes recruit apprentice permission")]
        public void TheEmployerChangesRecruitApprenticePermission()
        {
            permissions = (NewAddApprenticePermissions.AllowConditional, NewRecruitApprenticePermissions.AllowConditional);

            _yourTrainingProvidersPage
                .SelectChangePermissions(providerConfig.Ukprn)
                .SetPermissions(permissions)
                .VerifyYouHaveSetPermissionNotification();
        }

        [Then(@"an employer has to select at least one permission")]
        public void ThenAnEmployerHasToSelectAtLeastOnePermission()
        {
            EPRLogin();

            context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerProviderRelationships_BaseUrl(_objectContext.GetHashedAccountId()));

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

        private void EPRLogin()
        {
            _employerLoginHelper.Login(context.GetUser<EPRLevyUser>(), true);

            new DeleteProviderRelationHelper(context).DeleteProviderRelation();
        }
    }
}

