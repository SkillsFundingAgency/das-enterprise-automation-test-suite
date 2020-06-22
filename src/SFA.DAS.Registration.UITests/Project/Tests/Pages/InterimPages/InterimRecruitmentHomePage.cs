using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimRecruitmentHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your apprenticeship adverts";

        protected override string Linktext => "Adverts";

        public InterimRecruitmentHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimRecruitmentHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, gotourl) { }
    }
}
