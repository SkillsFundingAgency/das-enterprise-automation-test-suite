using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class ParentCompanyDetailsPage : RoatpBasePage
    {
        protected override string PageTitle => "Enter your organisation's ultimate parent company details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CompanyNumberField => By.Id("YO-21");

        private By CompanyNameField => By.Id("YO-22");

        public ParentCompanyDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IcoRegistrationNumberPage EnterParentCompanyDetailsAndContinue()
        {
            formCompletionHelper.EnterText(CompanyNumberField, applydataHelpers.CompanyNumber);
            formCompletionHelper.EnterText(CompanyNameField, applydataHelpers.CompanyName);
            Continue();
            return new IcoRegistrationNumberPage(_context);
        }
    }
}
