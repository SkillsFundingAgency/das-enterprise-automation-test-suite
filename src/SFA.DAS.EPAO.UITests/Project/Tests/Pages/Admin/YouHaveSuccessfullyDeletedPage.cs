using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class YouHaveSuccessfullyDeletedPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "You’ve successfully deleted";
        
        private By ReturnToStaffDashBoard => By.CssSelector(".govuk-button");

        public YouHaveSuccessfullyDeletedPage (ScenarioContext context) : base(context) => VerifyPage();

        public StaffDashboardPage ClickReturnToDashboard()
        {
            formCompletionHelper.ClickElement(ReturnToStaffDashBoard);
            return new StaffDashboardPage(_context);
        }
    }
}