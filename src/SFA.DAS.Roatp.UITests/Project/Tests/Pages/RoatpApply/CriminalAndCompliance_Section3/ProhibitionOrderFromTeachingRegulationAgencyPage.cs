using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class ProhibitionOrderFromTeachingRegulationAgencyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "prohibition order from the Teaching Regulation Agency on behalf of the Secretary of State for Education?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProhibitionOrderFromTeachingRegulationAgencyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public BanFromManagementOrGovernanceOfSchoolsPage SelectYesEnterInformationForProhibitionOrderFromTeachingRegulationAgencyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.ProhibitionOrderFromTeachingRegulationAgency);
            return new BanFromManagementOrGovernanceOfSchoolsPage(_context);
        }
    }
}
