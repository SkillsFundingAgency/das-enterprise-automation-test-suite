using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class ManageYourApprenticePageHelper(ScenarioContext context) : ApprovalsBasePage(context, false)
    {
        private static By ApprenticeSearchField => By.Id("searchTerm");

        private static By SearchButton => By.CssSelector(".das-search-form__button");

        private static By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");

        protected override string PageTitle => "";

        internal static By ViewApprenticeFullName(string linkText) => By.PartialLinkText(linkText);

        internal bool DoesApprenticeExists(string name)
        {
            List<IWebElement> apprentices = [];

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                SearchForApprentice(name);

                if (!(pageInteractionHelper.IsElementDisplayedAfterPageLoad(ViewApprenticeFullName(name))))
                {
                    Assert.Fail("Apprentice '" + name + "' is not found");
                }

                apprentices = [.. pageInteractionHelper.FindElements(ViewApprenticeFullName(name))];
            },
            RetryTimeOut.GetTimeSpan([10, 20, 30, 60, 120, 180]));

            return apprentices.Count > 0;
        }

        internal void SelectViewLiveApprenticeDetails(string name)
        {
            DoesApprenticeExists(name);

            var detailsLinks = pageInteractionHelper.FindElement(ViewApprenticeFullName(name));

            formCompletionHelper.ClickElement(detailsLinks);
        }


        internal void ClickOnDownloadFilteredDataCSVAndWaitForDownload() => formCompletionHelper.ClickElement(DownloadFilteredDataLink);

        internal bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        internal void DoesDownloadFileExistAndValidateRowCount()
        {
            var downloadedFileName = FileHelper.GetDownloadedFileName("Manageyourapprentices", "csv");

            Assert.IsNotEmpty(downloadedFileName);

            SetDebugInformation($"Downloaded file name is : '{downloadedFileName}'");

            TestContext.AddTestAttachment(downloadedFileName);

            var filteredApprenticesOnPage = tableRowHelper.GetTableRows();

            SetDebugInformation($"'{filteredApprenticesOnPage.Count}'apprentices found on the page before filter");

            filteredApprenticesOnPage = filteredApprenticesOnPage.Where(row =>
            {
                if (DateTime.TryParse(row["Planned end date"], out DateTime plannedEndDate))
                {
                    return plannedEndDate >= DateTime.Now.AddYears(-1);
                }
                return false;
            }).ToList();

            SetDebugInformation($"'{filteredApprenticesOnPage.Count}'apprentices found on the page after filter");

            int csvCount = FileHelper.CountCsvFileRows(downloadedFileName);

            int apprenticeCountinCsv = csvCount - 2;

            SetDebugInformation($"'{csvCount}'rows found in the csv");

            SetDebugInformation($"'{apprenticeCountinCsv}'apprentices found in the csv");

            Assert.That(filteredApprenticesOnPage.Count, Is.EqualTo(apprenticeCountinCsv), $"Downloaded '{downloadedFileName}' csv count mismatch");
        }

        private FilteredManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            // Search bar will not be displayed if there are less than 10 apprentice in the table
            if (pageInteractionHelper.IsElementDisplayed(ApprenticeSearchField))
            {
                formCompletionHelper.EnterText(ApprenticeSearchField, apprenticeName);

                formCompletionHelper.ClickElement(SearchButton);
            }

            return new FilteredManageYourApprenticesPage(context);
        }

    }
}

