using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WhatGradeInOfstedInspectionOverallEffectivenessPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What grade did your organisation get for overall effectiveness in this full Ofsted inspection?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhatGradeInOfstedInspectionOverallEffectivenessPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectForoverallEffectivenessGradeRequiresImprovementAndContinue()
        {
            SelectRadioOptionByText("Requires improvement");
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public GradeWithin3YearsPage SelectForoverallEffectivenessGradeInadequateAndContinue()
        {
            SelectRadioOptionByText("Inadequate");
            Continue();
            return new GradeWithin3YearsPage(_context);
        }
    }
}
