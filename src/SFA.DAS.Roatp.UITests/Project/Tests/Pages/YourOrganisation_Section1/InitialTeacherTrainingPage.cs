using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class InitialTeacherTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation offer initial teacher training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InitialTeacherTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FullOfstedInspectionPage SelectNoForITTAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new FullOfstedInspectionPage(_context);
        }
    }
}
