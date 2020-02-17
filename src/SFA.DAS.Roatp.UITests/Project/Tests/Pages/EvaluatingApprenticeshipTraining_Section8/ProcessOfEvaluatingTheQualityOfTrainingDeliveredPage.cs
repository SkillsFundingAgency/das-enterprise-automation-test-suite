using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.EvaluatingApprenticeshipTraining_Section8
{
    public class ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's process for evaluating the quality of training delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ImprovementsUsingProcessForEvaluatingPage EnterTextRegardingOrganisationProcessForEvaluatingTheQualityOfTrainingDeliveredAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EvaluatingQualityOfTrainingDelivered);
            return new ImprovementsUsingProcessForEvaluatingPage(_context);
        }
    }
}
