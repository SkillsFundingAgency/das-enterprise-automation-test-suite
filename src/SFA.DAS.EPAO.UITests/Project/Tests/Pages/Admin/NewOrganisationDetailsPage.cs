using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class NewOrganisationDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation details";

        public NewOrganisationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public OrganisationApplicationOverviewPage SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new OrganisationApplicationOverviewPage(context);
        }
    }
}

