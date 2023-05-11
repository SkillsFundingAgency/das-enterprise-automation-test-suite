using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubYouHaveSignedInPage : VerifyBasePage
    {
        protected override string PageTitle => "You've signed in";

        private static By MainContent => By.CssSelector("[id='main-content']");

        protected override By ContinueButton => By.CssSelector("a.govuk-button");

        public StubYouHaveSignedInPage(ScenarioContext context, EasAccountUser loginUser) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(MainContent, loginUser.Username),
                () => VerifyPage(MainContent, loginUser.IdOrUserRef)
            });
        }

        public HomePage ContinueToLogin()
        {
            Continue();
            return new HomePage(context);
        }

    }
}
