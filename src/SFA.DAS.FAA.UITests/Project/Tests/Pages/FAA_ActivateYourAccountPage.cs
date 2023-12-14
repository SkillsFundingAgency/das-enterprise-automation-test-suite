using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Activate your account";

        private static By ActivationCode => By.Id("ActivationCode");
        private static By ActivateAccount => By.Id("activate-button");
        private static By SignOut => By.Id("signout-link");

        public FAA_ActivateYourAccountPage2 EnterActivationCode()
        {
            formCompletionHelper.EnterText(ActivationCode, FAADataHelper.ActivationCode);
            formCompletionHelper.Click(ActivateAccount);
            pageInteractionHelper.WaitforURLToChange("tellusmore");
            return new FAA_ActivateYourAccountPage2(context);
        }

        public FAA_SignInPage ClickSignOut()
        {
            formCompletionHelper.Click(SignOut);
            return new FAA_SignInPage(context);
        }
    }
}