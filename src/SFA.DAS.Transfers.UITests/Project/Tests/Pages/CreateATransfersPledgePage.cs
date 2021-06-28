using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class CreateATransfersPledgePage : TransfersBasePage
    {
        private readonly ScenarioContext _context;
        public CreateATransfersPledgePage(ScenarioContext context) : base(context) => _context = context;

        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override string PageTitle => "Create a transfers pledge";
        //private By createTransfersPledgeButton = By.CssSelector("//a[@id='MainContent']/../h1");

        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }
    }
}
