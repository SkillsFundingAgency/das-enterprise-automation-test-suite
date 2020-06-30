using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimYourApprenticeshipAdvertsHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Adverts";

        public InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, gotourl) { }
    }
}
