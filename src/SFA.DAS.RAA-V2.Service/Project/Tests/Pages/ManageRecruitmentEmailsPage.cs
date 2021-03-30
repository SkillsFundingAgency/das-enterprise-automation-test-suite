using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageRecruitmentEmailsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Manage your recruitment emails";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#main-content > div:nth-child(2) > div > form > div:nth-child(3) > button");

        public ManageRecruitmentEmailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ManageRecruitmentEmailsSuccessfulPage SaveAndContinue()
        {
            Continue();
            return new ManageRecruitmentEmailsSuccessfulPage(_context);
        }
    }
}
