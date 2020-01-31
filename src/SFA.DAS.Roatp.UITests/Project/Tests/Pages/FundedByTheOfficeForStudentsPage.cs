using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class FundedByTheOfficeForStudentsPage : RoatpBasePage
    {
        protected override string PageTitle => "Is your organisation funded by the Office for Students?";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FundedByTheOfficeForStudentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InitialTeacherTrainingPage SelectYesForFundedbyOFSAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new InitialTeacherTrainingPage(_context);
        }
    }
}
