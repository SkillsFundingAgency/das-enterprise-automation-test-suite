using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AccessDeniedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Access denied";

        private readonly ScenarioContext _context;

        private string HomePageLinkText => "Go back to the service home page";

        public AccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage GoBackToTheServiceHomePage()
        {
            objectContext.UpdateOrganisationName(config.RE_OrganisationName);

            formCompletionHelper.ClickLinkByText(HomePageLinkText);
            
            return new HomePage(_context);
        }
    }
}