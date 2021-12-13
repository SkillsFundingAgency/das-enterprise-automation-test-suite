using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class ReviewProcessForEvaluatingTheQualityOfTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation review its process for evaluating the quality of training delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public ReviewProcessForEvaluatingTheQualityOfTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTextRegardingOrganisationReviewAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ReviewProcessForEvaluatingTheQualityOfTraining);
            return new ApplicationOverviewPage(_context);
        }
    }
}
