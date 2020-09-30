using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class AddYourOrgBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => "Add your organisation's bank account details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public AddYourOrgBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ProvideOrgInformationIntroductionPage ContinueToAddBankDetails()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new ProvideOrgInformationIntroductionPage(_context);
        }
    }
}
