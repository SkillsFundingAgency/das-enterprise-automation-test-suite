using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class FindABusinessPage : TransfersBasePage
    {
        private readonly ScenarioContext _context;
        public FindABusinessPage(ScenarioContext context) : base(context) => _context = context;

        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override string PageTitle => "Pledge and transfer your levy funds";
        private By continueButton = By.XPath("//*[text()='Start']");
        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }

        public void ClickContinue()
        {
            formCompletionHelper.ClickElement(ContinueButton);


        }
    }
}
