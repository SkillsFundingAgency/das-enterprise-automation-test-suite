using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class YourTransfersPage : TransfersBasePage
    {
        private readonly ScenarioContext _context;
        public YourTransfersPage(ScenarioContext context) : base(context) => _context = context;

        protected override By PageHeader => By.XPath("//*[@id='content']/h1");
        protected override string PageTitle => "Your Transfers";
        private By createTransfersPledgeButton = By.Id("CreateTransfersPledgeButton");

        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }
        public void ClickCreateATransfersPledge()
        {
            formCompletionHelper.ClickElement(createTransfersPledgeButton);


        }


    }
}
