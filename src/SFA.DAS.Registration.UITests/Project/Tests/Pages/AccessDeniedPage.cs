using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AccessDeniedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Access denied";
        private readonly ScenarioContext _context;

        public AccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage GoBackToTheServiceHomePage()
        {
            objectContext.UpdateOrganisationName(config.RE_OrganisationName);

            formCompletionHelper.ClickLinkByText("Go back to the service home page");
            
            return new HomePage(_context);
        }
    }
}