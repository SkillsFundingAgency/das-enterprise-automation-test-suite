using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class WhoHasThePersonWorkedPage : RoatpBasePage
    {
        protected override string PageTitle => "Who has this person worked with to develop and deliver training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhoHasThePersonWorkedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowHasThisPersonWorkedPage SelectEmployersOptions()
        {
            SelectRadioOptionByText("Employers - to deliver training to their employees");
            Continue();
            return new HowHasThisPersonWorkedPage(_context);
        }
    }
}
