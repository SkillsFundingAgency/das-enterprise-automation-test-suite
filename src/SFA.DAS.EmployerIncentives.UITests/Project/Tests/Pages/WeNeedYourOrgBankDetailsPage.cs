using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class WeNeedYourOrgBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => $"We need {ObjectContextExtension.GetOrganisationName(objectContext)}'s bank details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public WeNeedYourOrgBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public AddYourOrgBankDetailsPage ChooseYesAndContinue()
        {
            SelectRadioOptionByForAttribute("CanProvideBankDetails");
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new AddYourOrgBankDetailsPage(_context);
        }

        public ApplicationSavedPage ChooseNoAndContinue()
        {
            SelectRadioOptionByForAttribute("CanProvideBankDetails-2");
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new ApplicationSavedPage(_context);
        }
    }
}
