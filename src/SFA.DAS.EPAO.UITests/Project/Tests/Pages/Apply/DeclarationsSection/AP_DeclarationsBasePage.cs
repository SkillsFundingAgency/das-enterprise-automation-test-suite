using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.AuthoriserDetailsSubSection;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection
{
    public class AP_DeclarationsBasePage : EPAOApply_BasePage
    {
        protected override string PageTitle => "Declarations";
        private readonly ScenarioContext _context;

        #region Locators
        private By NameAndJobTitleLink => By.LinkText("Name and job title");
        #endregion

        public AP_DeclarationsBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DAD_1_AuthoriserDetailsPage ClickNameAndJobTitleLinkInDeclarationsBasePage()
        {
            formCompletionHelper.Click(NameAndJobTitleLink);
            return new AP_DAD_1_AuthoriserDetailsPage(_context);
        }
    }
}
