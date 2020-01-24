using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your UK ultimate parent company's full financial statements covering the last 12 months";

        protected override By PageHeader => By.TagName("h2");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChooseFile => By.ClassName("govuk-file-upload");

        public UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage UploadFullFinancialStatementsForTwelveMonthsAndContinue()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + "Project\\Framework\\UploadFiles\\" + "Sample.pdf";
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

    public class OtherSubsidiaryCompaniesPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your UK ultimate parent company have other subsidiary companies?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OtherSubsidiaryCompaniesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage ClickNoOnOtherSubsidiaryCompanies()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage(_context);
        }
    }
}
