using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class DoNotHavePermissionPage : DoNotHavePermissionBasePage
    {
        private readonly ScenarioContext _context;

        private By GoBackToHomePage => By.LinkText("Go back to home page");

        public DoNotHavePermissionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RecruitmentHomePage GoBackToTheServiceHomePage()
        {
            formCompletionHelper.ClickElement(GoBackToHomePage);
            return new RecruitmentHomePage(_context);
        }
    }
}
