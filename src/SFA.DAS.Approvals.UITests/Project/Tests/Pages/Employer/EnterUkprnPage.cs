using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
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
        #endregion

        private By TrainingProviderSearch => By.CssSelector("#Ukprn");
        private By FirstOption => By.CssSelector("#Ukprn__option--0");


        public EnterUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
        }

        public WhoWillEnterTheNewCourseDatesAndPrice ChooseTrainingProviderPage()
        {            
            Continue(_changeOfPartyConfig.Ukprn);

            return new WhoWillEnterTheNewCourseDatesAndPrice(_context);
        }

        internal EnterUkprnPage ChooseInvalidProvider()
        {
            Continue(_providerConfig.Ukprn);

            pageInteractionHelper.VerifyText(InvalidProivderErrorMessage, "Select another training provider - you cannot select the current training provider as the new training provider");

            ClearUKPRN();

            return new EnterUkprnPage(_context);
        }

        private void Continue(string ukprn) 
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, ukprn); return pageInteractionHelper.FindElement(FirstOption); });

            Continue();
        }

        private void ClearUKPRN() => javaScriptHelper.SetTextUsingJavaScript(TrainingProviderSearch, "");

    }
}
