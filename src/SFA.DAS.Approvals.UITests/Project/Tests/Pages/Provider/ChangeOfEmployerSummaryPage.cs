using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSummaryPage : ApprovalsBasePage
    {
        private readonly ScenarioContext _context;
        
        protected override string PageTitle => "Confirm the information before sending your request";
        protected override By ContinueButton => By.Id("confirm-button");

        public ChangeOfEmployerSummaryPage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfEmployerRequestedPage VerifyAndSubmitChangeOfEmployerRequest()
        {  
            var newStartDate = pageInteractionHelper.FindElement(By.Name("NewStartDate")).GetAttribute("value");
            var newEndDate = pageInteractionHelper.FindElement(By.Name("NewEndDate")).GetAttribute("value");
            var newPrice = pageInteractionHelper.FindElement(By.Name("NewPrice")).GetAttribute("value");

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
