using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AccountHomePage : TransferMatchingBasePage
    {
       protected override string PageTitle => objectContext.GetOrganisationName();
        
        public AccountHomePage(ScenarioContext context) : base(context) { }
     
        private By TaskSelector => By.CssSelector("#tasks > ul > li:nth-child(2) > span > a");
        
        public MyTransferPledgesPage ClickTask()
        {
            formCompletionHelper.Click(TaskSelector);
            
            return new MyTransferPledgesPage(context);
        }
    }
}