using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class OfftheJobTrainingIsRelevantPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation ensure 20% off the job training is relevant to the specific apprenticeship being delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OfftheJobTrainingIsRelevantPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForOffTheJobTrainingIsRelevantAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OffTheJobTraining);
            return new ApplicationOverviewPage(_context);
        }
    }

}
