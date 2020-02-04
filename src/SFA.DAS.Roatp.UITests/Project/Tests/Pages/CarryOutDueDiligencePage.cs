using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class CarryOutDueDiligencePage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation carry out due diligence on its subcontractors?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.Id("RTE-71");

        public CarryOutDueDiligencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForManagingRelationshipWithEmployersAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.ManagingRelationshipWithEmployers);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
