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

        private By LongTextArea_ImprovementsUsingProcessForEvaluating => By.Id("EAT-21");

        public ImprovementsUsingProcessForEvaluatingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingOrganisationImprovementsUsingEvaluatingTheQualityOfTrainingAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_ImprovementsUsingProcessForEvaluating, applydataHelpers.ImprovementsUsingProcessForEvaluating);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
