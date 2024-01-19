using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class AddYourOrgBankDetailsPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => $"Add {ObjectContextExtension.GetOrganisationName(objectContext)}'s organisation and finance details";

        public VRFIntroductionTabPage ContinueToVRFIntroductionTab1Page()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");
            return new VRFIntroductionTabPage(context);
        }
    }
}
