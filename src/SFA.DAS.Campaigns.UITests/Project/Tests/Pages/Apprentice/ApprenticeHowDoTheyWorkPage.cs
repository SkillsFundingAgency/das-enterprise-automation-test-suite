using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHowDoTheyWorkPage(ScenarioContext context) : ApprenticeBasePage(context)
    {
        protected override string PageTitle => "How do they work?";

        public void VerifyHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToHowDoTheyWorkPage());
    }
}