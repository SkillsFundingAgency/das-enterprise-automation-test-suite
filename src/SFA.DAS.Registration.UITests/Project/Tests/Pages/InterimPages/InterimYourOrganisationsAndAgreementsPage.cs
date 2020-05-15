using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class InterimYourOrganisationsAndAgreementsPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";
        protected override string Linktext => "Your organisations and agreements";

        public InterimYourOrganisationsAndAgreementsPage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}