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
        protected override string PageTitle => "Find a business to transfer your levy to by creating a transfers pledge";
        private By continueButton = By.XPath("//*[@id='main-content']/div/div/div/a[1]");
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
