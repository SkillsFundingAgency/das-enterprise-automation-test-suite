using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class SubjectToInvestigationByESFAorPublicBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation currently, or has within the last 5 years been, subject to an investigation by the ESFA or other public body or regulator?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubjectToInvestigationByESFAorPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InsolvencyOrWindingUpProceedingsPage SelectYesEnterInformationForInvestigatedbyESFAorPublicbodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InvestigatedDueToWhistleBlowingIssues);
            return new InsolvencyOrWindingUpProceedingsPage(_context);
        }
    }
}