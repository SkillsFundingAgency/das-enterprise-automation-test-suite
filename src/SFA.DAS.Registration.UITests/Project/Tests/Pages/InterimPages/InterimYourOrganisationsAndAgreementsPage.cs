using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class InterimYourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate) : InterimEmployerBasePage(context, navigate)
    {
        protected override string PageTitle => "Your organisations and agreements";

        protected override string Linktext => "Your organisations and agreements";
    }
}