using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AccountHomePage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override string AccessibilityPageTitle => "Employer home page";

        private static By TaskSelector => By.CssSelector("#tasks a[href*='pledges']");

        public MyTransferPledgesPage ClickTask()
        {
            formCompletionHelper.Click(TaskSelector);

            return new MyTransferPledgesPage(context);
        }
    }
}