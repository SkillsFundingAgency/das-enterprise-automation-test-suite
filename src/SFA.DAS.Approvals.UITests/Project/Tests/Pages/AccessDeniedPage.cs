using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class AccessDeniedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "You do not have permission to access this page";

        private readonly ScenarioContext _context;

        //   protected virtual string GoBackToHomePage => "Go back to home page"; 

        private By X = By.XPath("//*[@id='main - content']/div/div/p[2]/a");

        public AccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprovalsProviderHomePage GoBackToTheServiceHomePage()
        {
            formCompletionHelper.ClickElement(X);
            return new ApprovalsProviderHomePage(_context);
        }
    }
}
