using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.EvaluatingApprenticeshipTraining_Section8
{
    public class ReviewProcessForEvaluatingTheQualityOfTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation review its process for evaluating the quality of training delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_ReviewProcessForEvaluatingTheQualityOfTraining => By.Id("EAT-50");

        public ReviewProcessForEvaluatingTheQualityOfTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingOrganisationReviewAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_ReviewProcessForEvaluatingTheQualityOfTraining, applydataHelpers.ReviewProcessForEvaluatingTheQualityOfTraining);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
