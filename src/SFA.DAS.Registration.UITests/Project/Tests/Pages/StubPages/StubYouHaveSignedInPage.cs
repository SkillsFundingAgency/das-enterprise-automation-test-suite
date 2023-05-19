using OpenQA.Selenium;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.TestDataCleanup;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport.SqlHelpers;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
{
    public class StubYouHaveSignedInPage : VerifyBasePage
    {
        protected override string PageTitle => "You've signed in";

        private static By MainContent => By.CssSelector("[id='main-content']");

        protected override By ContinueButton => By.CssSelector("a.govuk-button");

        public StubYouHaveSignedInPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(MainContent, username),
                () => newUser || VerifyPage(MainContent, idOrUserRef)
            });

            if (newUser)
            {
                idOrUserRef = new UsersSqlDataHelper(context.Get<DbConfig>()).GetUserId(username);

                objectContext.UpdateLoginIdOrUserRef(username, idOrUserRef);

                objectContext.SetOrUpdateUserCreds(username, idOrUserRef);

                objectContext.SetDbNameToTearDown(CleanUpDbName.EasUsersTestDataCleanUp, username);
            }
        }

        public MyAccountTransferFundingPage ContinueToMyAccountTransferFundingPage()
        {
            Continue();
            return new MyAccountTransferFundingPage(context);
        }

        public YourAccountsPage ContinueToYourAccountsPage()
        {
            Continue();
            return new YourAccountsPage(context);
        }

        public HomePage ContinueToHomePage()
        {
            Continue();
            return new HomePage(context);
        }

        public StubAddYourUserDetailsPage ContinueToStubAddYourUserDetailsPage()
        {
            Continue();
            return new StubAddYourUserDetailsPage(context);
        }

    }
}
