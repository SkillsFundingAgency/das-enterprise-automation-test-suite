using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ApplicationOutcomePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application ";

        protected By InternalComments => By.CssSelector("p.govuk-body.das-multiline-text");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    
        public void VerifyExternalComments(string internalComments) => pageInteractionHelper.VerifyText(InternalComments, internalComments);

        public ApplicationOutcomePage VerifyApplicationOutcomePage(string expectedPage, string externalComments)
        {   
            pageInteractionHelper.VerifyText(PageHeader, expectedPage);
            
            if (!(string.IsNullOrEmpty(externalComments))) { VerifyExternalComments(externalComments); }
            
            return this;
        }
        public MakeAnAppealPage StartAppeal ()
        {
            Continue();
            return new MakeAnAppealPage(_context);
        }

        public InvitationRequestedPage RequestNewInvitation()
        {
            Continue();
            return new InvitationRequestedPage(_context);
        }
    }
}
