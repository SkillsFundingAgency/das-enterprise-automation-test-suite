using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHowDoTheyWorkPage : ApprenticeBasePage
    {
        protected override string PageTitle => "How do they work?";

        public ApprenticeHowDoTheyWorkPage(ScenarioContext context) : base(context) { }

        public void VerifyHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToHowDoTheyWorkPage());
    }
}