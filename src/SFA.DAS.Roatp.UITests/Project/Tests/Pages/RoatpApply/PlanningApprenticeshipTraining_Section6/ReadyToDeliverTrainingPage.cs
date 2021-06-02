using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class ReadyToDeliverTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us how your organisation is ready to deliver training in apprenticeship standards";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReadyToDeliverTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EndPointAssesmentOrganisationsPage EnterTextRegardingReadyToDeliverTrainingAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ReadytoDeliverTraining);
            return new EndPointAssesmentOrganisationsPage(_context);
        }
    }
}
