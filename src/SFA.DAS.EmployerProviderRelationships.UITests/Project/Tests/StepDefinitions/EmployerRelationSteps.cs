using NUnit.Framework;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerRelationSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
    {
        [Given(@"Levy employer grants all permission to a provider")]
        public void LevyEmployerGrantsAllPermissionToAProvider()
        {
            permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

            EPRLevyUserLogin();

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
            EPRLevyUserLogin();

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

        [Then(@"the employer is unable to add an existing provider")]
        public void ThenTheEmployerIsUnableToAddAnExistingProvider()
        {
            new YourTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions()
                .SelectAddATrainingProvider()
                .SearchForAnExistingTrainingProvider(providerConfig);

            new AlreadyLinkedToTrainingProviderPage(context).CannotAddExistingTrainingProvider();
        }

        [Then(@"the employer accepts the request")]
        public void TheEmployerAcceptsTheRequest()
        {
            EPRReLogin();

            AcceptOrDeclineProviderPermissionsRequest(true);
        }

        [Then(@"the employer declines the request")]
        public void TheEmployerDeclinesTheRequest()
        {
            EPRReLogin();

            AcceptOrDeclineProviderPermissionsRequest(false);
        }


        [Then(@"the employer accepts the updated request")]
        public void TheEmployerAcceptsTheUpdatedRequest()
        {
            
        }

        private void AcceptOrDeclineProviderPermissionsRequest(bool doesAllow)
        {
            _employerPermissionsStepsHelper.AcceptOrDeclineProviderPermissionsRequest(providerConfig, eprDataHelper.RequestId, doesAllow);
        }

    }
}