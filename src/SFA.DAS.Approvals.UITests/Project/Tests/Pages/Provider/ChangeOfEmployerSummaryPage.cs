using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSummaryPage : BasePage
    {
        private PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Confirm the information before sending your request";
        public ChangeOfEmployerSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        

        public ChangeOfEmployerRequestedPage VerifyAndSubmitChangeOfEmployerRequest()
        {  
            var newStartDate = _pageInteractionHelper.FindElement(By.Name("NewStartDate")).GetAttribute("value");
            var newEndDate = _pageInteractionHelper.FindElement(By.Name("NewEndDate")).GetAttribute("value");
            var newPrice = _pageInteractionHelper.FindElement(By.Name("NewPrice")).GetAttribute("value");

            Assert.AreEqual(FormatDateIntoMMYYYY(DateTime.Now), newStartDate);
            Assert.AreEqual(FormatDateIntoMMYYYY(DateTime.Now.AddYears(1)), newEndDate);
            Assert.AreEqual("1002", newPrice);

            Continue();
            return new ChangeOfEmployerRequestedPage(_context);
        }

        private string FormatDateIntoMMYYYY(DateTime date)
        {
            var prefix = date.Month < 10 ? "0" : "";
            return $"{prefix}{date.Month}{date.Year}";
        }
    }
}
