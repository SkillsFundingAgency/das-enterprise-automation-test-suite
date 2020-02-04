using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's process for evaluating the quality of training delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_EvaluatingQualityOfTrainingDelivered => By.Id("EAT-20");

        public ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ImprovementsUsingProcessForEvaluatingPage EnterTextRegardingOrganisationProcessForEvaluatingTheQualityOfTrainingDeliveredAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_EvaluatingQualityOfTrainingDelivered, applydataHelpers.EvaluatingQualityOfTrainingDelivered);
            Continue();
            return new ImprovementsUsingProcessForEvaluatingPage(_context);
        }
    }
}
