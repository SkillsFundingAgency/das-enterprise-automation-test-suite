using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimCreateAnAdvertHomePage : InterimYourApprenticeshipAdvertsHomePage
    {
        protected override string PageTitle => "Create an advert";

        public InterimCreateAnAdvertHomePage(ScenarioContext context) : base(context, true)
        {

        }
    }

    public class InterimYourApprenticeshipAdvertsHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your apprenticeship adverts";

        protected override string Linktext => "Adverts";

        public InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimYourApprenticeshipAdvertsHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, gotourl) { }
    }
}
