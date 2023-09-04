using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AccountHomePage : TransferMatchingBasePage
    {
       protected override string PageTitle => objectContext.GetOrganisationName();
        
        public AccountHomePage(ScenarioContext context) : base(context) { }

        private static By TaskSelector => By.CssSelector("#application-approval-task > a");

        public MyTransferPledgesPage ClickTask()
        {
            formCompletionHelper.Click(TaskSelector);
            
            return new MyTransferPledgesPage(context);
        }
    }
}