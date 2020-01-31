using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ManageRelationshipWithEmployerPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation manage its relationship with employers?";

        protected override By PageHeader => By.TagName("h2");

        private By LongTextArea => By.Id("RTE-21");

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
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.ManagingRelationshipWithEmployers);
            Continue();
            return new ResponsibleForManagingRelationshipsPage(_context);
        }
    }
}
