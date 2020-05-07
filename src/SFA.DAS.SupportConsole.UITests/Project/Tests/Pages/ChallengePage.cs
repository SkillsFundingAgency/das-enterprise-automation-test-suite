using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ChallengePage : BasePage
    {
        protected override string PageTitle => "Enter the following information to verify the caller";

        protected override By PageHeader => By.CssSelector(".lede");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly SupportConsoleConfig _config;
        private readonly RegexHelper _regexHelper;
        private readonly char[] _payeschemechars;
        #endregion

        private By Challenge1 => By.Id("challenge1");
        private By Challenge2 => By.Id("challenge2");
        private By LevyBalance => By.Id("balance");
        private By Challenge_ErrorMessage => By.CssSelector(".error-summary");
        private By SubmitButton => By.CssSelector(".button");
        private By PayeChallengeLabel => By.CssSelector("label[for='challenge1']");

        public ChallengePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            _regexHelper = context.Get<RegexHelper>();
            _payeschemechars = _config.PayeScheme.Replace("/", string.Empty).ToCharArray();
        }

        public void EnterIncorrectPaye() => EnterPayeChallenge("2", "2");
    
        public void EnterCorrectPaye()
        {
            string func(int position) => _payeschemechars.ElementAt(position - 1).ToString();

            var text = _pageInteractionHelper.GetText(PayeChallengeLabel);
            
            (int x, int y) = _regexHelper.GetPayeChallenge(text);

            EnterPayeChallenge(func(x), func(y));
        }

        public void EnterCorrectLevybalance() => _formCompletionHelper.EnterText(LevyBalance, _config.CurrentLevyBalance);

        public void Submit() => _formCompletionHelper.ClickElement(SubmitButton);

        public void VerifyChallengeResponseErrorMessage(string errorMessage) => _pageInteractionHelper.VerifyText(Challenge_ErrorMessage, errorMessage);

        private void EnterPayeChallenge(string char1, string char2)
        {
            _formCompletionHelper.EnterText(Challenge1, char1);
            _formCompletionHelper.EnterText(Challenge2, char2);
        }
    }
}
