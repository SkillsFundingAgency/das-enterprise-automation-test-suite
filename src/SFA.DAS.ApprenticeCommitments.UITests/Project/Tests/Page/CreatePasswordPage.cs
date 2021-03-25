using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreatePasswordPage : PasswordBasePage
    {
        protected override string PageTitle => "Create password";

        private readonly ScenarioContext _context;

        public CreatePasswordPage(ScenarioContext context) : base(context) => _context = context;

        public YourAccountHasBeenCreatedPage CreatePassword()
        {
            SubmitPassword(_validPassword, _validPassword);
            return new YourAccountHasBeenCreatedPage(_context);
        }
    }
}
