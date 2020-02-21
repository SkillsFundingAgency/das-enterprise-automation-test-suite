using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class ManageRelationshipWithEmployerPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation manage its relationship with employers?";

        protected override By PageHeader => By.TagName("h2");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ManageRelationshipWithEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ResponsibleForManagingRelationshipsPage EnterTextForManagingRelationshipWithEmployersAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ManagingRelationshipWithEmployers);
            return new ResponsibleForManagingRelationshipsPage(_context);
        }
    }
}
