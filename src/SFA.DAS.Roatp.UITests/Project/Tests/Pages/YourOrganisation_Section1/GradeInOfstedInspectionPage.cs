using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class GradeInOfstedInspectionPage : RoatpBasePage
    {
        protected override string PageTitle => "Did your organisation get a grade for apprenticeships in this full Ofsted inspection?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GradeInOfstedInspectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhatGradeInOfstedInspectionPage SelectYesForGradeInFullOfstedInspectionAndContinue()
        {
            SelectYesAndContinue();
            return new WhatGradeInOfstedInspectionPage(_context);
        }
    }
}
