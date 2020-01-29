using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OfftheJobTrainingIsRelevantPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation ensure 20% off the job training is relevant to the specific apprenticeship being delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_OffTheJobTraining => By.Id("PAT-651");
        
        public OfftheJobTrainingIsRelevantPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        
        public ApplicationOverviewPage EnterTextForOffTheJobTrainingIsRelevantAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_OffTheJobTraining, applydataHelpers.OffTheJobTraining);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
