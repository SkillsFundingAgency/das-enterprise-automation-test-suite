using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StandardsDetailsPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "View organisation standard";

        public StandardsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public OrganisationDetailsPage ReturnToOrganisationDetailsPage() => ReturnToOrganisationDetailsPage(() => formCompletionHelper.ClickLinkByText("Return to organisation"));
        
    }    
}
