using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public abstract class ApprenticeshipTrainingCourseBasePage : FATV2BasePage
    {
        protected override string PageTitle => "Apprenticeship training courses";

        protected override bool TakeFullScreenShot => false;

        public ApprenticeshipTrainingCourseBasePage(ScenarioContext context) : base(context) { }
    }
}
