using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class InvitationRequestedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Invitation requested";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InvitationRequestedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
