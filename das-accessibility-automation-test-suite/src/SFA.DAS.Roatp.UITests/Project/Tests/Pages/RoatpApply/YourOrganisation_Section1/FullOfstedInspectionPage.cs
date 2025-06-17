using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class FullOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had a full Ofsted inspection in further education and skills?";

        public FullOfstedInspectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public MonitoringVisitPage SelectNoForFullOfstedInspectionAndContinue()
        {
            SelectNoAndContinue();
            return new MonitoringVisitPage(context);
        }

        public GradeInOfstedInspectionPage SelectYesForFullOfstedInspectionAndContinue()
        {
            SelectYesAndContinue();
            return new GradeInOfstedInspectionPage(context);
        }
    }
}
