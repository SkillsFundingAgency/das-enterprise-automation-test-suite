using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class EndPointAssesmentOrganisationsPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation engage with end-point assessment organisations (EPAO's)?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_EngageWithEPAO => By.Id("PAT-900");

        public EndPointAssesmentOrganisationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AwardingBodiesPage EnterTextRegardingEngageWithEPAOandContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_EngageWithEPAO, applydataHelpers.EngageWithEPAO);
            Continue();
            return new AwardingBodiesPage(_context);
        }
    }
}
