using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.TestDataCleanup;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourIdentityPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your identity";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By AccessCodeInput => By.Id("AccessCode");
        protected override By ContinueButton => By.CssSelector("input.button");
        #endregion

        public ConfirmYourIdentityPage(ScenarioContext context, string email, string password) : base(context)
        { 
            VerifyPage();

            objectContext.SetOrUpdateUserCreds(email, password);

            objectContext.SetDbNameToTearDown(CleanUpDbName.EasUsersTestDataCleanUp, email);
        }

        public AddAPAYESchemePage ContinueToGetApprenticeshipFunding()
        {
            EnterAccessCodeAndContinue();

            return new AddAPAYESchemePage(context);
        }

        private void EnterAccessCodeAndContinue() { formCompletionHelper.EnterText(AccessCodeInput, string.Empty); Continue(); }
    }
}