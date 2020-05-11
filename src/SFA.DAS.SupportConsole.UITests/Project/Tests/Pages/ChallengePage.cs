using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ChallengePage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Enter the following information to verify the caller";

        protected override By PageHeader => By.CssSelector(".lede");

        #region Helpers and Context
        private char[] _payeschemechars;
        #endregion

        private By Challenge1 => By.Id("challenge1");
        private By Challenge2 => By.Id("challenge2");
        private By LevyBalance => By.Id("balance");
        private By Challenge_ErrorMessage => By.CssSelector(".error-summary");
        private By SubmitButton => By.CssSelector(".button");
        private By PayeChallengeLabel => By.CssSelector("label[for='challenge1']");

        public ChallengePage(ScenarioContext context) : base(context) { }

        public void EnterIncorrectPaye() => EnterPayeChallenge("2", "2");
    
        public void EnterCorrectPaye()
        {
            string func(char[] chars, int position)
            {
                var digit = chars.ElementAt(position - 1).ToString();
                objectContext.Set($"challenge position {position}", digit);
                return digit;
            }

            _payeschemechars = config.PayeScheme.Replace("/", string.Empty).ToCharArray();

            var text = pageInteractionHelper.GetText(PayeChallengeLabel);
            
            (int x, int y) = regexHelper.GetPayeChallenge(text);

            EnterPayeChallenge(func(_payeschemechars, x), func(_payeschemechars, y));
        }

        public void EnterCorrectLevybalance() => formCompletionHelper.EnterText(LevyBalance, config.CurrentLevyBalance);

        public void Submit() => formCompletionHelper.ClickElement(SubmitButton);

        public void VerifyChallengeResponseErrorMessage(string errorMessage) => pageInteractionHelper.VerifyText(Challenge_ErrorMessage, errorMessage);

        private void EnterPayeChallenge(string char1, string char2)
        {
            formCompletionHelper.EnterText(Challenge1, char1);
            formCompletionHelper.EnterText(Challenge2, char2);
        }
    }
}
