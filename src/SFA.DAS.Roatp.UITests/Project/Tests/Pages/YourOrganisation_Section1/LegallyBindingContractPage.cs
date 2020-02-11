using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class LegallyBindingContractPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload a copy of a legally binding contract between your organisation and a main or employer provider";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public LegallyBindingContractPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage UploadLegallyBindingContractAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }
}
