using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ContactDetailsPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "View contact";

        public ContactDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
    }  
}