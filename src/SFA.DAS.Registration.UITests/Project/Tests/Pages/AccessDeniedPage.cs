using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AccessDeniedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Access denied";

        protected virtual string HomePageLinkText => "Go back to the service home page";

        public AccessDeniedPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage GoBackToTheServiceHomePage() => GoBackToTheServiceHomePage(registrationDataHelper.CompanyTypeOrg);

        public HomePage GoBackToTheServiceHomePage(string orgName)
        {
            objectContext.UpdateOrganisationName(orgName);
            formCompletionHelper.ClickLinkByText(HomePageLinkText);
            return new HomePage(_context);
        }
    }
}