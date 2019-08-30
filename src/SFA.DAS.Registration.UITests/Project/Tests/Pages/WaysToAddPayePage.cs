using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class WaysToAddPayePage : BasePage
    {
        protected override string PageTitle => "Ways to add your PAYE scheme";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By UseGGRadioButton => By.CssSelector("label[for=want-to-use-gov-gateway]");

        private By UseAccountOfficeRadioButton => By.CssSelector("label[for=want-to-use-aorn]");

        private By ContinueButton => By.Id("submit-how-to-add-payescheme");


        public WaysToAddPayePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public GatewayInformPage SelectGovermentGateway()
        {
            GovermentGateway().
                Continue();
            return new GatewayInformPage(_context);
        }

        private WaysToAddPayePage GovermentGateway()
        {
            _formCompletionHelper.ClickElement(UseGGRadioButton);
            return this;
        }

        private WaysToAddPayePage AcountOffice()
        {
            _formCompletionHelper.ClickElement(UseAccountOfficeRadioButton);
            return this;
        }

        private WaysToAddPayePage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}