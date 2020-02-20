using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class InsolvencyOrWindingUpProceedingsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation or any of its partner organisations been subject to insolvency or winding up proceedings in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InsolvencyOrWindingUpProceedingsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesEnterInformationForSubjectToInsolvencyOrWindingUpProceedingsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InsolvencyOrWindingUpProceedings);
            return new ApplicationOverviewPage(_context);
        }
    }
}