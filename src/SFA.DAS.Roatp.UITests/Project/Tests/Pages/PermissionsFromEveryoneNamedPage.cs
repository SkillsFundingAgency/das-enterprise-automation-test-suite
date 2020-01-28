using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class PermissionsFromEveryoneNamedPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you have permission from everyone named in this application to use their details?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PermissionsFromEveryoneNamedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public CheckedWithEveryonePage SelectYesForPermissionsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new CheckedWithEveryonePage(_context);
        }
    }

}
