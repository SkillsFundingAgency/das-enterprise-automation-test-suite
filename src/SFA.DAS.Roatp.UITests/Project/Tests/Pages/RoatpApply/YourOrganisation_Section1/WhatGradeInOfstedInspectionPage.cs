using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WhatGradeInOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What grade did your organisation get for apprenticeships in this full Ofsted inspection?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatGradeInOfstedInspectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhatGradeInOfstedInspectionOverallEffectivenessPage SelecRequiresImprovementAndContinue()
        {
            SelectRadioOptionByText("Requires improvement");
            Continue();
            return new WhatGradeInOfstedInspectionOverallEffectivenessPage(_context);
        }

        public GradeWithin3YearsPage SelecOutstandingAndContinue()
        {
            
            SelectRadioOptionByText("Outstanding");
            Continue();
            return new GradeWithin3YearsPage(_context);
        }
    }
}
