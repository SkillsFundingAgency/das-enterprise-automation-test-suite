using System;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ReportsDashboardPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Reports";

        private readonly By CreateNewReportLink = By.LinkText("Create new report");
        private readonly By ProcessingStatusSpan = By.XPath("//table[contains(@class,'govuk-table')]/tbody//td[contains(@class,'govuk-table__cell--numeric')]/span[normalize-space(.)='Processing']");
        private readonly By RefreshPageLink = By.LinkText("Check if your report is ready to download");
        private readonly By TableDownloadLinks = By.CssSelector("table.govuk-table a.govuk-link");

        public CreateANewReportPage ClickCreateNewReportLink()
        {
            formCompletionHelper.Click(CreateNewReportLink);
            return new CreateANewReportPage(context);
        }

        public ReportsDashboardPage VerifyCSVDownloadLink()
        {
            var maxAttempts = 5;

            if (maxAttempts <= 0) throw new ArgumentOutOfRangeException(nameof(maxAttempts));

            var attempts = 0;

            while (pageInteractionHelper.IsElementPresent(ProcessingStatusSpan) && attempts < maxAttempts)
            {
                attempts++;
                formCompletionHelper.Click(RefreshPageLink);
                pageInteractionHelper.WaitForPageToLoad();
            }

            var links = pageInteractionHelper.FindElements(TableDownloadLinks);
            if (links == null || links.Count == 0)
                throw new Exception("No download links found in the reports table.");

            var firstLink = links.First();
            var href = firstLink.GetAttribute("href") ?? string.Empty;

            pageInteractionHelper.VerifyText(href, "download-csv");

            return this;
        }

    }
}