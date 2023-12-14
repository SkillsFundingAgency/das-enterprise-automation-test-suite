using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoESummaryPage(ScenarioContext context) : ApprovalsBasePage(context)
    {

        protected override string PageTitle => "Confirm the information before sending your request";
        protected override By ContinueButton => By.Id("confirm-button");

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

        private static string FormatDateIntoMMYYYY(DateTime date)
        {
            var prefix = date.Month < 10 ? "0" : "";
            return $"{prefix}{date.Month}{date.Year}";
        }
    }
}
