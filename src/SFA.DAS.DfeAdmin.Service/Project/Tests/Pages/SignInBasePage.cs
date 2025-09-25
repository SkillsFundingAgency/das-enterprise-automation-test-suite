using NUnit.Framework;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using System.Threading;
//using static SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.SignInBasePage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public abstract class SignInBasePage(ScenarioContext context) : IdamsLoginBasePage(context)
{
    private static readonly Lock _mfaObject = new();

    static readonly List<string> usedCodes = [];

    public abstract class DfeMFaBasePage : VerifyBasePage
    {
        public DfeMFaBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.UpdateTimeSpans(RetryTimeOut.GetTimeSpan([5, 5, 5, 5, 5]));

            VerifyPage();
        }
    }

    public class EnterPasswordMFAPage(ScenarioContext context) : DfeMFaBasePage(context)
    {
        public static string EnterPasswordMFAPageIdentifierCss => "div[id='loginHeader']";

        public static string EnterPasswordMFAPageTitle => "Enter password";

        protected override By PageHeader => By.CssSelector(EnterPasswordMFAPageIdentifierCss);

        protected override string PageTitle => EnterPasswordMFAPageTitle;

        private static By PasswordField => By.CssSelector("input[name=passwd][type=password]");

        private static By MFASignInButton => By.CssSelector("input[type='submit'][value='Sign in']");

        public void SubmitValidPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordField, password);

            formCompletionHelper.ClickElement(MFASignInButton);
        }
    }

    private class VeifyYourIdentityMFAPage(ScenarioContext context) : DfeMFaBasePage(context)
    {
        protected override By PageHeader => By.CssSelector("div[id='pageContent']");

        protected override string PageTitle => "Verify your identity";

        private static By MFAEmailCodeButton => By.CssSelector("button[data-testid='Email'][type='button']");

        public void SubmitEmailCode()
        {
            formCompletionHelper.ClickElement(MFAEmailCodeButton);
        }
    }

    private class EmailAuthCodeMFAPage(ScenarioContext context) : DfeMFaBasePage(context)
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
                var codes = context.Get<MailosaurApiHelper>().GetDfeMfaCodes(email, "Your DfE Sign-in (PREPROD) account verification code", "Account verification code:");

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

    private class CheckStaySignedInMFAPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
    {
        protected override string PageTitle => StaySignedInMFAPage.StaySignedInMFAPageTitle;

        protected override By Identifier => StaySignedInMFAPage.StaySignedInMFAPageIdentifier;
    }

    private class StaySignedInMFAPage(ScenarioContext context) : DfeMFaBasePage(context)
    {
        public static string StaySignedInMFAPageTitle => "Stay signed in?";

        public static By StaySignedInMFAPageIdentifier => By.CssSelector("div.text-title[role='heading']");

        protected override By PageHeader => StaySignedInMFAPageIdentifier;

        protected override string PageTitle => StaySignedInMFAPageTitle;

        private static By MFAStaySignInYesButton => By.CssSelector("input[type='submit'][value='Yes']");

        public void SubmitYes()
        {
            formCompletionHelper.ClickElement(MFAStaySignInYesButton);
        }
    }


    public class EnterPasswordPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        public static string EnterPasswordPageTitle => "Enter your password";

        public static string EnterPasswordPageIdentifierCss => "#password";

        protected override string PageTitle => EnterPasswordPageTitle;

        private static By PasswordField => By.CssSelector(EnterPasswordPageIdentifierCss);

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
        formCompletionHelper.EnterText(UsernameField, username);
        
        Continue();

        if (EnvironmentConfig.IsPPEnvironment)// && new CheckEnterPasswordMFAOrStandardPage(context).IsEnterPasswordMFADisplayed())
        {
            lock (_mfaObject)
            {
                new EnterPasswordMFAPage(context).SubmitValidPassword(password);

                new VeifyYourIdentityMFAPage(context).SubmitEmailCode();

                new EmailAuthCodeMFAPage(context).SubmitValidAuthCode(username);

                if (new CheckStaySignedInMFAPage(context).IsPageDisplayed())
                {
                    new StaySignedInMFAPage(context).SubmitYes();
                }
            }
        }
        else
        {
            new EnterPasswordPage(context).SubmitValidPassword(password);

            ClickSignInButton();
        }

    }

    protected virtual void ClickSignInButton() => formCompletionHelper.ClickElement(SignInButton);
}

// 24/09/2025 - PLEASE DO NOT REMOVE COMMENTED CODE

//public class CheckEnterPasswordMFAOrStandardPage(ScenarioContext context) : CheckMultipleHomePage(context)
//{
//    public override string[] PageIdentifierCss => [EnterPasswordMFAPage.EnterPasswordMFAPageIdentifierCss, EnterPasswordPage.EnterPasswordPageIdentifierCss];

//    public override string[] PageTitles => [EnterPasswordMFAPage.EnterPasswordMFAPageTitle, EnterPasswordPage.EnterPasswordPageTitle];

//    public bool IsEnterPasswordMFADisplayed() => ActualDisplayedPage(EnterPasswordMFAPage.EnterPasswordMFAPageTitle);
//}
