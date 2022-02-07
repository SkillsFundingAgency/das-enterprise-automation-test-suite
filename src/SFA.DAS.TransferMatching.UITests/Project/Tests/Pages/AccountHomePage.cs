using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SFA.DAS.UI.FrameworkHelpers;

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

