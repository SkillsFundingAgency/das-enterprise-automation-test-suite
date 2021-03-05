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

        private By SecureFundingGoBackToHomePage = By.LinkText("Go back to home page");

        public AccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprovalsProviderHomePage GoBackToTheServiceHomePage()
        {
            formCompletionHelper.ClickElement(SecureFundingGoBackToHomePage);
            return new ApprovalsProviderHomePage(_context);
        }
    }
}
