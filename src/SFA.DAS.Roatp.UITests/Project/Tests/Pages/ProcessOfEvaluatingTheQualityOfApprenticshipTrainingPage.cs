using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation's process for evaluating the quality of training delivered include apprenticeship training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ReviewProcessForEvaluatingTheQualityOfTrainingPage yesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ReviewProcessForEvaluatingTheQualityOfTrainingPage(_context);
        }
    }

}
