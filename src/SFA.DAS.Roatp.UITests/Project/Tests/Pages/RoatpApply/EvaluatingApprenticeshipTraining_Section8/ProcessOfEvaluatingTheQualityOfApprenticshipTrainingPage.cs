using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage : RoatpApplyBasePage
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

        public ReviewProcessForEvaluatingTheQualityOfTrainingPage YesAndContinue()
        {
            SelectYesAndContinue();
            return new ReviewProcessForEvaluatingTheQualityOfTrainingPage(_context);
        }
    }
}
