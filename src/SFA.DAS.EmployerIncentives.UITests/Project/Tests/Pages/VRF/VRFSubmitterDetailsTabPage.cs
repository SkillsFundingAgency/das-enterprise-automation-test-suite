using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFSubmitterDetailsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Form submitter details";

        #region Locators
        private readonly ScenarioContext _context;
        private By FirstName => By.CssSelector("#user_firstname");
        private By Surname => By.CssSelector("#user_surname");
        private By Email => By.CssSelector("#user_email_address");
        private By Telephone => By.CssSelector("#user_telephone");
        #endregion

        public VRFSubmitterDetailsTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchToFrame(By.CssSelector("iframe.achieveforms-iframe"));
            VerifyPage();
            //frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

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

            return new VRFSummaryTabPage(_context);
        }
    }
}
