using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ReadyToDeliverTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "How is your organisation ensuring it's ready to deliver training in apprenticeship standards?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_ReadytoDeliverTraining => By.Id("PAT-30");

        public ReadyToDeliverTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EndPointAssesmentOrganisationsPage EnterTextRegardingReadyToDeliverTrainingAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_ReadytoDeliverTraining, applydataHelpers.ReadytoDeliverTraining);
            Continue();
            return new EndPointAssesmentOrganisationsPage(_context);
        }
    }
}
