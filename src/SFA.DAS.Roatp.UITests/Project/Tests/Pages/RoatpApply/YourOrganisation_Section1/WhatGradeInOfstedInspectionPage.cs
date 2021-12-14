using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WhatGradeInOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What grade did your organisation get for apprenticeships in this full Ofsted inspection?";

        public WhatGradeInOfstedInspectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatGradeInOfstedInspectionOverallEffectivenessPage SelecRequiresImprovementAndContinue()
        {
            SelectRadioOptionByText("Requires improvement");
            Continue();
            return new WhatGradeInOfstedInspectionOverallEffectivenessPage(context);
        }

        public GradeWithin3YearsPage SelecOutstandingAndContinue()
        {
            
            SelectRadioOptionByText("Outstanding");
            Continue();
            return new GradeWithin3YearsPage(context);
        }

        public GradeWithin3YearsPage SelecInadequateAndContinue()
        {

            SelectRadioOptionByText("Inadequate");
            Continue();
            return new GradeWithin3YearsPage(context);
        }
    }
}
