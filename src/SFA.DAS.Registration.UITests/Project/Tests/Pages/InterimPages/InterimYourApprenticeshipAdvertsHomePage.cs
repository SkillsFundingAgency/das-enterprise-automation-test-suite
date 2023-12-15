using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimCreateAnAdvertHomePage(ScenarioContext context) : InterimYourApprenticeshipAdvertsHomePage(context, true)
    {
        protected override string PageTitle => "Create an advert";
    }

    public class InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate, bool gotourl) : InterimEmployerBasePage(context, navigate, gotourl)
    {
        protected override string PageTitle => "Your apprenticeship adverts";

        protected override string Linktext => "Adverts";

        public InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }
    }
}
