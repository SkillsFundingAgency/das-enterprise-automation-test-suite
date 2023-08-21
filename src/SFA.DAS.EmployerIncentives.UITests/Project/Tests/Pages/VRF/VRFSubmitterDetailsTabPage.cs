using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFSubmitterDetailsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Form submitter details";

        #region Locators
        private static By FirstName => By.CssSelector("#user_firstname");
        private static By Surname => By.CssSelector("#user_surname");
        private static By Email => By.CssSelector("#user_email_address");
        private static By Telephone => By.CssSelector("#user_telephone");
        #endregion

        public VRFSubmitterDetailsTabPage(ScenarioContext context) : base(context, false) => frameHelper.SwitchFrameAndAction(() => VerifyPage());

        public VRFSummaryTabPage SubmitSubmitterDetails(string email)
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(FirstName, eIDataHelper.FirstName);
                formCompletionHelper.EnterText(Surname, eIDataHelper.SurName);
                formCompletionHelper.EnterText(Email, email);
                SelectOptionByText("genric_email_address", "No");
                formCompletionHelper.EnterText(Telephone, eIDataHelper.TelephoneNumber);
                Continue();
            });

            return new VRFSummaryTabPage(context);
        }
    }
}
