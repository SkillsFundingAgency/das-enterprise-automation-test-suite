using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeshipIndicativeEarningsReportPage : ApprovalsBasePage
    {
        private static DateTime _currentAcademicYearStartDate;
        private static By ExpectedTotalOnProgrammeEarningsHeading => By.XPath($"//h2[text()='Estimated earnings for academic year {_currentAcademicYearStartDate.Year} to {_currentAcademicYearStartDate.Year + 1}']");
        private static By TotalEarningsValue => By.XPath("//h3[text()='Total earnings'] /following-sibling::p");
        private static By LevyEarningsValue => By.XPath("//h3[text()='Levy earnings'] /following-sibling::p");
        private static By NonLevyEarningsValue => By.XPath("//h3[text()='Non-levy earnings'] /following-sibling::p");
        private static By NonLevyGovernmentContribution => By.XPath("//h3[text()='Non-levy government contribution'] /following-sibling::p");
        private static By NonLevyEmployerContribution => By.XPath("//h3[text()='Non-levy employer contribution'] /following-sibling::p");
        protected override string PageTitle => "Estimated earnings from apprentices on the Simplified Payments pilot";

        public ProviderApprenticeshipIndicativeEarningsReportPage(ScenarioContext context) : base(context)
        {
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
            //ValidateUIElementsOnPage();
        }

        public void ValidateUIElementsOnPage() => Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ExpectedTotalOnProgrammeEarningsHeading), "Total on-programme earnings heading not displayed");

        public void ValidateEarnings((string totalEarnings, string levyEarnings, string nonLevyEarnings, string nonLevyGovernmentContribution, string nonLevyEmployerContribution) earnings)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(earnings.totalEarnings, pageInteractionHelper.GetText(TotalEarningsValue), "Incorrect Total earnings found");
                Assert.AreEqual(earnings.levyEarnings, pageInteractionHelper.GetText(LevyEarningsValue), "Incorrect Levy earnings found");
                Assert.AreEqual(earnings.nonLevyEarnings, pageInteractionHelper.GetText(NonLevyEarningsValue), "Incorrect Non-levy earnings found");
                Assert.AreEqual(earnings.nonLevyGovernmentContribution, pageInteractionHelper.GetText(NonLevyGovernmentContribution), "Incorrect Non-levy Government contribution found");
                Assert.AreEqual(earnings.nonLevyEmployerContribution, pageInteractionHelper.GetText(NonLevyEmployerContribution), "Incorrect Non-levy employer contribution found");
            });
        }
    }
}