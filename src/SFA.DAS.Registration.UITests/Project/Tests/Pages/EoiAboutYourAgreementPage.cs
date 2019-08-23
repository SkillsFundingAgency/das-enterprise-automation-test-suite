using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EoiAboutYourAgreementPage : BasePage
    {
        protected override string PageTitle => "About this document";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ContinueButton => By.CssSelector("input.button");

        public EoiAboutYourAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public EoiSignAgreementPage ContinueWithEoiAgreement()
        {
            EoiAgreement();
            return new EoiSignAgreementPage(_context);
        }

        private EoiAboutYourAgreementPage EoiAgreement()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}