using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class FundingRemovedFromEducationBodiesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had funding removed from any education bodies in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FundingRemovedFromEducationBodiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RemovedFromProfessionalOrTradeRegistersPage SelectYesEnterInformationForFundingRemovedFromEducationBodiesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.FundingRemovedFromEducationBodies);
            return new RemovedFromProfessionalOrTradeRegistersPage(_context);
        }
    }
}