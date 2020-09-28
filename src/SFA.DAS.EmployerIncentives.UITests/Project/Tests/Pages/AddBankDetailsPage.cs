using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class AddBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => "We need your organisation's bank details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public AddBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public void SubmitAddBankDetails()
        {
            SelectRadioOptionByForAttribute("CanProvideBankDetails");
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
        }

    }
}
