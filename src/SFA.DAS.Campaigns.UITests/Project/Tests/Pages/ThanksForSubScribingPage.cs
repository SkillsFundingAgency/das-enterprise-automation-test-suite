using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ThanksForSubScribingPage: BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;

        #endregion

        #region Constants
        private const string ExpectedThanksForSubScribingHeader = "THANKS FOR SUBSCRIBING";
        #endregion

        #region Page Objects Elements
        private readonly By _thanksForSubscribingHeader = By.ClassName("heading-xl");
        private readonly By _firstsecondname = By.ClassName("heading-emphasise");
        #endregion
        public ThanksForSubScribingPage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

        }

        internal ThanksForSubScribingPage VerifyThanksForSubScribingPage()
        {
            _pageInteractionHelper.VerifyText(_thanksForSubscribingHeader, ExpectedThanksForSubScribingHeader);
            return new ThanksForSubScribingPage(_context);
        }

        internal ThanksForSubScribingPage VerifyEmployerName()
        {
            _pageInteractionHelper.VerifyText(_firstsecondname, RunTimevariable._employerFirstName + ' ' + RunTimevariable._employerLastName);
            return new ThanksForSubScribingPage(_context);
        }

    }
}