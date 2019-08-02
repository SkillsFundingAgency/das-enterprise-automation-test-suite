using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class GetApprenticeshipFunding : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly PayeAccountDetails _config;
        #endregion

        private By AddPayeRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme]");

        private By DoNotAddPayeRadioButton => By.CssSelector("label[for=do-not-want-to-add-paye-scheme]");

        private By ContinueButton => By.Id("submit-confirm-who-you-are-button");

        public GetApprenticeshipFunding(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetConfigSection<PayeAccountDetails>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Get apprenticeship funding";

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
            return new GetApprenticeshipFunding(_context);
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