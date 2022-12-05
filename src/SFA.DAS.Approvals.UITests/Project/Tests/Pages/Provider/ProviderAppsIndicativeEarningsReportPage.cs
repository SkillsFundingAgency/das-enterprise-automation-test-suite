using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAppsIndicativeEarningsReportPage : ApprovalsBasePage
    {
        private static DateTime _currentAcademicYearStartDate;
        private static By ExpectedTotalOnProgrammeEarningsHeading => By.XPath($"//h2[text()='Expected total on-programme earnings in current academic year ({_currentAcademicYearStartDate.Year} to {_currentAcademicYearStartDate.Year + 1})']");
        private static By TotalEarningsHeading => By.XPath("//h3[text()='Total earnings']");
        private static By TotalEarningsValue => By.XPath("//h3[text()='Total earnings'] /following-sibling::p");
        private static By LevyEarningsHeading => By.XPath("//h3[text()='Levy earnings']");
        private static By LevyEarningsValue => By.XPath("//h3[text()='Levy earnings'] /following-sibling::p");
        private static By NonLevyEarningsHeading => By.XPath("//h3[text()='Non-levy earnings']");
        private static By NonLevyEarningsValue => By.XPath("//h3[text()='Non-levy earnings'] /following-sibling::p");
        private static By DownloadSumaryReportButton => By.XPath("//a[text()='Download CSV Summary report']");
        protected override string PageTitle => "Apps indicative earnings report";

        public ProviderAppsIndicativeEarningsReportPage(ScenarioContext context) : base(context) 
        {
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
        }

        public void ValidateUIElementsOnPage()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ExpectedTotalOnProgrammeEarningsHeading), "Total on-programme earnings heading not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(TotalEarningsHeading), "Total earnings Heading not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(LevyEarningsHeading), "Levy earnings heading not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(NonLevyEarningsHeading), "Non-levy earnings heading not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(DownloadSumaryReportButton), "Download sumary report button not displayed");
        }

        public void ValidateEarnings (string TotalEarnings, string LevyEarnings, string NonLevyEarnings)
        {
            Assert.AreEqual(pageInteractionHelper.GetText(TotalEarningsValue), "£" + TotalEarnings, "Incorrect Total earnings found");
            Assert.AreEqual(pageInteractionHelper.GetText(LevyEarningsValue), "£" + LevyEarnings, "Incorrect Levy earnings found");
            Assert.AreEqual(pageInteractionHelper.GetText(NonLevyEarningsValue), "£" + NonLevyEarnings, "Incorrect Non-levy earnings found");
        }
    }
}
