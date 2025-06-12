using NUnit.Framework;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using System.Threading;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public abstract class SignInBasePage(ScenarioContext context) : IdamsLoginBasePage(context)
{
    private static readonly Mutex _mfaObject = new();

    static readonly List<string> usedCodes = [];

    private class EnterPasswordMFAPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("div[id='loginHeader']");

        protected override string PageTitle => "Enter password";

        private static By PasswordField => By.CssSelector("input[name=passwd][type=password]");

        private static By MFASignInButton => By.CssSelector("input[type='submit'][value='Sign in']");

        public void SubmitValidPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordField, password);

            formCompletionHelper.ClickElement(MFASignInButton);
        }
    }

    private class VeifyYourIdentityMFAPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("div[id='pageContent']");

        protected override string PageTitle => "Verify your identity";

        private static By MFAEmailCodeButton => By.CssSelector("button[data-testid='Email'][type='button']");

        public void SubmitEmailCode()
        {
            formCompletionHelper.ClickElement(MFAEmailCodeButton);
        }
    }

    private class EmailAuthCodeMFAPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("div[id='pageContent']");

        protected override string PageTitle => "Enter code";

        private static By EmailAuthCodeField => By.CssSelector("input[type='tel'][name='otc']");

        private static By CodeError => By.CssSelector("div[id='undefinedError'][role='alert']");

        private static By MFAEmailCodeVerifyButton => By.CssSelector("button[type='submit'][id='oneTimeCodePrimaryButton']");

        public void SubmitValidAuthCode(string email)
        {
            context.Get<RetryAssertHelper>().RetryOnDfeSignMFAAuthCode(() =>
            {
                var codes = context.Get<MailosaurApiHelper>().GetCodes(email, "Your DfE Sign-in (TEST) account verification code", "Account verification code:");

                SetDebugInformation($"Used codes are ({usedCodes.Select(x => $"'{x}'").ToString(",")})");

                SetDebugInformation($"Codes from email are ({codes.Select(x => $"'{x}'").ToString(",")})");

                var notusedcodes = codes.Except(usedCodes);

                Assert.That(notusedcodes.Any(), "All email codes are used");

                var code = notusedcodes.First();

                formCompletionHelper.EnterText(EmailAuthCodeField, code);

                formCompletionHelper.ClickElement(MFAEmailCodeVerifyButton);

                Assert.That(pageInteractionHelper.FindElements(CodeError).Count == 0, $"code error locator {CodeError} has been found");

                usedCodes.Add(code);
            });
        }
    }

    private class StaySignedInMFAPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("div.text-title[role='heading']");

        protected override string PageTitle => "Stay signed in?";

        private static By MFAStaySignInYesButton => By.CssSelector("input[type='submit'][value='Yes']");

        public void SubmitYes()
        {
            formCompletionHelper.ClickElement(MFAStaySignInYesButton);
        }
    }


    private class EnterPasswordPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override string PageTitle => "Enter your password";

        private static By PasswordField => By.Id("password");

        public void SubmitValidPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordField, password);
        }
    }

    protected override By PageHeader => By.CssSelector(".pageTitle");

    protected override bool TakeFullScreenShot => false;

    protected override string PageTitle => "Sign in";

    protected override By ContinueButton => By.XPath("//button[contains(text(),'Next')]");

    #region Locators
    private static By UsernameField => By.Id("username");

    private static By SignInButton => By.XPath("//button[@value='Log in']");

    #endregion

    public void SubmitValidLoginDetails(string username, string password)
    {
        void EnterUserName()
        {
            formCompletionHelper.EnterText(UsernameField, username);

            Continue();
        }

        if (username.StartsWith("mfa"))
        {
            lock (_mfaObject)
            {
                EnterUserName();

                new EnterPasswordMFAPage(context).SubmitValidPassword(password);

                new VeifyYourIdentityMFAPage(context).SubmitEmailCode();

                new EmailAuthCodeMFAPage(context).SubmitValidAuthCode(username);

                new StaySignedInMFAPage(context).SubmitYes();
            }
        }
        else
        {
            EnterUserName();

            new EnterPasswordPage(context).SubmitValidPassword(password);

            ClickSignInButton();
        }

    }

    protected virtual void ClickSignInButton() => formCompletionHelper.ClickElement(SignInButton);
}
