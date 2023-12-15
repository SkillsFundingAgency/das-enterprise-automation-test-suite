using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ConfirmAccountDeletionPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Confirm account deletion";

        private static By DeleteAccountButton => By.Id("DeleteAccountAction");

        public FAA_SignInPage DeleteAccount()
        {
            formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_SignInPage(context);
        }
    }
}
