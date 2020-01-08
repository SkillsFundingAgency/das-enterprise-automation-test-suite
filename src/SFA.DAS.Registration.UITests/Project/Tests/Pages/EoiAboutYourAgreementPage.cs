using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EoiAboutYourAgreementPage : BasePage
    {
        protected override string PageTitle => "About your agreement";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("input.govuk-button, input.button");

        public EoiAboutYourAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EoiSignAgreementPage ContinueWithEoiAgreement()
        {
            Continue();
            return new EoiSignAgreementPage(_context);
        }
    }
}