using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ChangeBankDetailsPage : EIBasePage
    {
        protected override string PageTitle => $"Change {ObjectContextExtension.GetOrganisationName(objectContext)}'s bank details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public ChangeBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public VRFIntroductionTabPage ContinueToVRFIntroductionTab1Page()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new VRFIntroductionTabPage(_context);
        }
    }
}
