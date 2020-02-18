using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.EvaluatingApprenticeshipTraining_Section8
{
    public class ImprovementsUsingProcessForEvaluatingPage : RoatpBasePage
    {
        protected override string PageTitle => "How has your organisation made improvements using its process for evaluating the quality of training delivered?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ImprovementsUsingProcessForEvaluatingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingOrganisationImprovementsUsingEvaluatingTheQualityOfTrainingAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ImprovementsUsingProcessForEvaluating);
            return new ApplicationOverviewPage(_context);
        }
    }
}
