using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class PermissionsUpdatedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully changed";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PermissionsUpdatedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public new HomePage GoToHomePage()
        {
            SelectRadioOptionByForAttribute("choice-3");
            Continue();
            return new HomePage(_context);
        }
    }
}
