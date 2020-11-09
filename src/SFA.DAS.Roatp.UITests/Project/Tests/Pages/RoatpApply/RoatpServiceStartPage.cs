using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class RoatpServiceStartPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Register of apprenticeship training providers";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApplyNow => By.LinkText("Apply now");

        public RoatpServiceStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UsedThisServiceBeforePage ClickApplyNow()
        {
            formCompletionHelper.ClickElement(ApplyNow);
            return new UsedThisServiceBeforePage(_context);
        }
    }
}
