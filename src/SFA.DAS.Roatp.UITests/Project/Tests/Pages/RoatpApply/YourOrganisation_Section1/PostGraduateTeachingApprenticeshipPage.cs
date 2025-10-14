using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class PostGraduateTeachingApprenticeshipPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is the postgraduate and/or undergraduate teaching apprenticeships the only apprenticeship programmes your organisation intends to deliver?";

        public PostGraduateTeachingApprenticeshipPage(ScenarioContext context) : base(context) => VerifyPage();

        public FullOfstedInspectionPage SelectNoForPGTAAndContinue()
        {
            SelectNoAndContinue();
            return new FullOfstedInspectionPage(context);
        }
        public ApplicationOverviewPage SelectYesForPGTAAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(context);
        }
    }
}
