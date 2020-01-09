using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class IdamsPage : BasePage
    {
        protected override string PageTitle => "Sign in using your account on:";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public IdamsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPageAfterRefresh(RAAStaffIdams);
        }
        
        #region Properties
        private By RAAStaffIdams => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        private By RAAAccess1StaffIdams => By.XPath("//span[contains(text(),'Access1 Staff')]");
        #endregion

        public void RecruitStaffIdams()
        {
            _formCompletionHelper.Click(RAAStaffIdams);
        }

        public void ManageStaffIdams()
        {
            _formCompletionHelper.Click(RAAAccess1StaffIdams);
        }      
    }
}
