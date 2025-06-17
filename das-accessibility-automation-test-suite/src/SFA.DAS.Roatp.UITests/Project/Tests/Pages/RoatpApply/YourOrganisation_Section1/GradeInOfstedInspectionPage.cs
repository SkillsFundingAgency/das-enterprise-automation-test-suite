using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class GradeInOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Did your organisation get a grade for apprenticeships in this full Ofsted inspection?";

        public GradeInOfstedInspectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatGradeInOfstedInspectionPage SelectYesForGradeInFullOfstedInspectionAndContinue()
        {
            SelectYesAndContinue();
            return new WhatGradeInOfstedInspectionPage(context);
        }

        public WhatGradeInOfstedInspectionOverallEffectivenessPage SelectNoForGradeInFullOfstedInspectionAndContinue()
        {
            SelectNoAndContinue();
            return new WhatGradeInOfstedInspectionOverallEffectivenessPage(context);
        }
    }
}
