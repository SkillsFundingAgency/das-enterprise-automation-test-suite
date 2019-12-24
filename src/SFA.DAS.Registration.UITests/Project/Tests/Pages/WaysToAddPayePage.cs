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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By UseGGRadioButton => By.CssSelector("label[for=want-to-use-gov-gateway]");

        private By UseAccountOfficeRadioButton => By.CssSelector("label[for=want-to-use-aorn]");

        protected override By ContinueButton => By.Id("submit-how-to-add-payescheme");


        public WaysToAddPayePage(ScenarioContext context) : base(context)
        {
            _context = context;
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
    }
}