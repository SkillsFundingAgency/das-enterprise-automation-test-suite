using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.SupportConsole.UITests.Project.SqlHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnDetailsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => config.UlnName;

        #region Locators
        private By ApprenticeNameSelector => By.CssSelector(".column-three-quarters.column__double-padding-left.column__border-left .grid-row .column-full .heading-large");

        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        #endregion
        public UlnDetailsPage(ScenarioContext context) : base(context) 
        { 
            VerifyApprenticeNameHeading();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        private void VerifyApprenticeNameHeading()
        {
            pageInteractionHelper.VerifyText(ApprenticeNameSelector, PageTitle);
        }
        

        public void VerifyUlnDetailsPageHeaders()
        {
            //VerifyPage();
            VerifyHeader("Agreement status");
            VerifyHeader("Payment status", "td strong");
            VerifyHeaderAndValue("Unique learner number", config.Uln);
            VerifyHeaderAndValue("Name", config.UlnName);
            VerifyHeaderAndValue("Cohort reference", config.CohortRef);
            VerifyHeader("Legal entity");
            VerifyHeader("UKPRN");
            VerifyHeader("AS training start date");
            VerifyHeader("AS training end date");
            VerifyHeader("Current training cost");
        }


        private void VerifyHeaderAndValue(string headerText, string headerValue)
        {
            var headerTextXpathQuery = $"//th[contains(text(),'{headerText}')]";
            var header = pageInteractionHelper.FindElement(By.XPath(headerTextXpathQuery));
            var parent = header.FindElement(By.XPath(".."));
            var value = parent.FindElement(By.CssSelector("td"));
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(header), headerText);
            pageInteractionHelper.VerifyText(headerValue, pageInteractionHelper.GetText(value));
        }


        private void VerifyHeader(string headerText, string valueCssSelector = "td")
        {
            var headerTextXpathQuery = $"//th[contains(text(),'{headerText}')]";
            var header = pageInteractionHelper.FindElement(By.XPath(headerTextXpathQuery));
            var parent = header.FindElement(By.XPath(".."));
            var value = parent.FindElement(By.CssSelector(valueCssSelector));
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(header), headerText);
        }
    }
}