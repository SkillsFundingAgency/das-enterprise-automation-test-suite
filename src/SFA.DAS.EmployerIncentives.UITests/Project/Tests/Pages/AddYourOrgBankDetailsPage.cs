using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class AddYourOrgBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => $"Add {ObjectContextExtension.GetOrganisationName(objectContext)}'s organisation and finance details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public AddYourOrgBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public VRFIntroductionTabPage ContinueToVRFIntroductionTab1Page()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new VRFIntroductionTabPage(_context);
        }
    }
}
