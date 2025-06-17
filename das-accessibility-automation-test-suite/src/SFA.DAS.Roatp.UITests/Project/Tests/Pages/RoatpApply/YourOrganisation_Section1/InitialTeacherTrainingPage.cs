using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{

    public class InitialTeacherTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation offer initial teacher training?";

        public InitialTeacherTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public FullOfstedInspectionPage SelectNoForITTAndContinue()
        {
            SelectNoAndContinue();
            return new FullOfstedInspectionPage(context);
        }

        public PostGraduateTeachingApprenticeshipPage SelectYesForITTAndContinue()
        {
            SelectYesAndContinue();
            return new PostGraduateTeachingApprenticeshipPage(context);
        }

        public ApplicationOverviewPage ClickContinueForDescribeYourOrgDetailsSelected()
        {
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
