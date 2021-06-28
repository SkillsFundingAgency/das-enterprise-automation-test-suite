using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterUkprnPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.TagName("h1");
        protected override string PageTitle => "Enter the new training provider's name or reference number (UKPRN)";
        protected override By ContinueButton => By.Id("Ukprn-button");
        private By InvalidProivderErrorMessage = By.LinkText("Select another training provider - you cannot select the current training provider as the new training provider");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ChangeOfPartyConfig _changeOfPartyConfig;
        private readonly ProviderConfig _providerConfig;
        private readonly JavaScriptHelper _javaScriptHelper;
        #endregion


        private By TrainingProviderSearch => By.CssSelector("#Ukprn");
        private By FirstOption => By.CssSelector("#Ukprn__option--0");


        public EnterUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
            _javaScriptHelper = _context.Get<JavaScriptHelper>();
        }

        public WhoWillEnterTheNewCourseDatesAndPrice ChooseTrainingProviderPage()
        {            
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, _changeOfPartyConfig.Ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new WhoWillEnterTheNewCourseDatesAndPrice(_context);
        }

        internal EnterUkprnPage ChooseInvalidProvider()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, _providerConfig.Ukprn); return pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            pageInteractionHelper.VerifyText(InvalidProivderErrorMessage, "Select another training provider - you cannot select the current training provider as the new training provider");
            clearUKPRN();

            return new EnterUkprnPage(_context);
        }

        private void clearUKPRN() => _javaScriptHelper.SetTextUsingJavaScript(TrainingProviderSearch, "");

    }
}
