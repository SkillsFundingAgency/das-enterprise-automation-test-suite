using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class Idams : BasePage
    {
        protected override string PageTitle => "Sign in using your account on:";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        public Idams(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage(RAAStaffIdams);
        }
        
        #region Properties
        private By RAAStaffIdams => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        private By RAAAccess1StaffIdams => By.XPath("//span[contains(text(),'Access1 Staff')]");
        #endregion

        public SignInPage RecruitStaffIdams()
        {
            _formCompletionHelper.Click(RAAStaffIdams);
            return new SignInPage(_context);
        }

        public SignInPage ManageStaffIdams()
        {
            _formCompletionHelper.Click(RAAAccess1StaffIdams);
            return new SignInPage(_context);
        }      
    }
}
