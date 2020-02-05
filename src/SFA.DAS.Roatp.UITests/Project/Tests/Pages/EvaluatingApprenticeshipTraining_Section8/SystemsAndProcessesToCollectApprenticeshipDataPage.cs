using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.EvaluatingApprenticeshipTraining_Section8
{
    public class SystemsAndProcessesToCollectApprenticeshipDataPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have systems and processes in place to collect apprenticeship data?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SystemsAndProcessesToCollectApprenticeshipDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SubmitILRDataPage SelectYesAndContinueOnCollectingDataPage()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new SubmitILRDataPage(_context);
        }
    }
}
