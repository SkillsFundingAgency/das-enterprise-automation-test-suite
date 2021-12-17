using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ShortOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had a short Ofsted inspection within the last 3 years?";

        public ShortOfstedInspectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public MaintainedTheGradeInOfsteadInspectionPage SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
        {
            SelectYesAndContinue();
            return new MaintainedTheGradeInOfsteadInspectionPage(context);
        }
    }
}
