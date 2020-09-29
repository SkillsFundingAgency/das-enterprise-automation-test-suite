using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideSubmitterDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "Form submitter details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By FirstName => By.CssSelector("#user_firstname");

        private By Surname => By.CssSelector("#user_surname");

        private By Email => By.CssSelector("#user_email_address");

        private By Telephone => By.CssSelector("#user_telephone");

        public ProvideSubmitterDetailsPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public ProvideSummaryDetailsPage SubmitSubmitterDetails(string email)
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(FirstName, "FirstName");
                formCompletionHelper.EnterText(Surname, "Surname");
                formCompletionHelper.EnterText(Email, email);
                SelectOptionByText("genric_email_address", "No");
                formCompletionHelper.EnterText(Telephone, "01234567899");
                Continue();
            });

            return new ProvideSummaryDetailsPage(_context);
        }
    }
}
