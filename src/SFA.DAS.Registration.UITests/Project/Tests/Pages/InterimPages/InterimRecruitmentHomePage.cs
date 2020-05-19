using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimRecruitmentHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruitment";

        public InterimRecruitmentHomePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        public InterimRecruitmentHomePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, gotourl) { }
    }
}
