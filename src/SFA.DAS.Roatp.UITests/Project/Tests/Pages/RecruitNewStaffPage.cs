using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class RecruitNewStaffPage : RoatpBasePage
    {
        protected override string PageTitle => "Will your organisation recruit new staff to deliver training against these forecasts?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RecruitNewStaffPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TypicalRatioOfStaffPage SelectYesRecruitNewStaffAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TypicalRatioOfStaffPage(_context);
        }
    }
}
