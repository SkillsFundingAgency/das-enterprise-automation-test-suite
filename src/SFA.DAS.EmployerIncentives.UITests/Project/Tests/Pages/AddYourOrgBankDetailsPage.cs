using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class AddYourOrgBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => $"Add {ObjectContextExtension.GetOrganisationName(objectContext)}'s bank account details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public AddYourOrgBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public VRFIntroductionTab1Page ContinueToAddBankDetails()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new VRFIntroductionTab1Page(_context);
        }
    }
}
