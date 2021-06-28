using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class SubmitILRDataPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have the resources to submit Individualised Learner Record (ILR) data?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubmitILRDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IndividualAccountableForILRPage SelectYesAndContinueonILRpage()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new IndividualAccountableForILRPage(_context);
        }
    }
}
