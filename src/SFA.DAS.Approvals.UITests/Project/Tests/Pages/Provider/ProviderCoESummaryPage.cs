using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoESummaryPage : ApprovalsBasePage
    {

        protected override string PageTitle => "Confirm the information before sending your request";
        protected override By ContinueButton => By.Id("confirm-button");

        public ProviderCoESummaryPage(ScenarioContext context) : base(context) { }

        public ProviderCoERequestedPage VerifyAndSubmitChangeOfEmployerRequest()
        {
            var newStartDate = pageInteractionHelper.FindElement(By.CssSelector(".govuk-table:nth-child(6) tr:nth-child(2) > td:nth-child(2)")).Text;
            var newEndDate = pageInteractionHelper.FindElement(By.CssSelector(".govuk-table:nth-child(6) tr:nth-child(3) > td:nth-child(2)")).Text;
            var newPrice = pageInteractionHelper.FindElement(By.CssSelector(".govuk-table:nth-child(6) tr:nth-child(4) > td:nth-child(2)")).Text;

            Assert.AreEqual(FormatDateIntoMMYYYY(DateTime.Now), FormatDateIntoMMYYYY(DateTime.Parse(newStartDate)));
            Assert.AreEqual(FormatDateIntoMMYYYY(DateTime.Now.AddYears(1)), FormatDateIntoMMYYYY(DateTime.Parse(newEndDate)));
            Assert.AreEqual("1002", newPrice.Replace("£", "").Replace(",", ""));

            Continue();

            return new ProviderCoERequestedPage(context);
        }

        private string FormatDateIntoMMYYYY(DateTime date)
        {
            var prefix = date.Month < 10 ? "0" : "";
            return $"{prefix}{date.Month}{date.Year}";
        }
    }
}
