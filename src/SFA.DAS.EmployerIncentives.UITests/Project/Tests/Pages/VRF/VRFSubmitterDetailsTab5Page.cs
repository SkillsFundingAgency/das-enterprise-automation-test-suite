using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFSubmitterDetailsTab5Page : VRFBasePage
    {
        protected override string PageTitle => "Form submitter details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By FirstName => By.CssSelector("#user_firstname");

        private By Surname => By.CssSelector("#user_surname");

        private By Email => By.CssSelector("#user_email_address");

        private By Telephone => By.CssSelector("#user_telephone");

        public VRFSubmitterDetailsTab5Page(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFSummaryTab6Page SubmitSubmitterDetails(string email)
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

            return new VRFSummaryTab6Page(_context);
        }
    }
}
