using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class ProviderRequestPermissionsPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        protected override string PageTitle => $"Add employer and request permissions";

        public RequestSentToEmployerPage ProviderRequestPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
        {
            SetAddApprentice(permisssion.cohortpermission);

            SetRecruitApprentice(permisssion.recruitpermission);

            return new(context);
        }
    }
}
