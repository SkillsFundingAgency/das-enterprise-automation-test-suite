using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GetApprenticeshipFunding : BasePage
    {
        protected override string PageTitle => "Add a PAYE Scheme";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        #endregion

        private By AddPayeRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme]");

        private By DoNotAddPayeRadioButton => By.CssSelector("label[for=do-not-want-to-add-paye-scheme]");

        private By ContinueButton => By.Id("submit-add-a-paye-scheme-button");

        public GetApprenticeshipFunding(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public GatewayInformPage AddPaye()
        {
            SelectAddPaye().
                Continue();
            return new GatewayInformPage(_context);
        }

        public MyAccountWithOutPaye DoNotAddPaye()
        {
            SelectDoNotAddPaye().
                Continue();
            return new MyAccountWithOutPaye(_context);
        }

        private GetApprenticeshipFunding SelectAddPaye()
        {
            _formCompletionHelper.ClickElement(AddPayeRadioButton);
            return this;
        }

        private GetApprenticeshipFunding SelectDoNotAddPaye()
        {
            _formCompletionHelper.ClickElement(DoNotAddPayeRadioButton);
            return this;
        }

        private GetApprenticeshipFunding Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}