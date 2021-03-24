using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DoNotHavePermissionBasePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "You do not have permission to access this page";

        private readonly ScenarioContext _context;

        private By GoBackToHomePage => By.LinkText("Go back to home page");

        public DoNotHavePermissionBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
