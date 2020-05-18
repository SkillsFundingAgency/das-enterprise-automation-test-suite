using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimHomeBasePage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override string Linktext => "Home";

        public InterimHomeBasePage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}