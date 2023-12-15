using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate = false) : Navigate(context, navigate)
    {
        protected override string PageTitle => "Organisations and agreements";

        protected override string Linktext => "Organisations and agreements";
    }
}
