using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class EqualityAndDiversityPolicyPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's equality and diversity policy";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EqualityAndDiversityPolicyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EqualityAndDiversityPolicyFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }

    }

}
