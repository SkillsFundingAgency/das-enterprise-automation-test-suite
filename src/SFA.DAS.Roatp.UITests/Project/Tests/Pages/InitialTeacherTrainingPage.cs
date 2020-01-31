using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
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
            SelectRadioOptionByForAttribute("YO-240_1");
            Continue();
            return new FullOfstedInspectionPage(_context);
        }
    }
}
