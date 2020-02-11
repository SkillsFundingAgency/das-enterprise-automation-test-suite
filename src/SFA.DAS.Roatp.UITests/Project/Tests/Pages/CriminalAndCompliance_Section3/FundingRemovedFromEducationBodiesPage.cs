using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class FundingRemovedFromEducationBodiesPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation had funding removed from any education bodies in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_FundingRemovedFromEducationBodies => By.Id("CC-24.1");

        public FundingRemovedFromEducationBodiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RemovedFromProfessionalOrTradeRegistersPage SelectYesEnterInformationForFundingRemovedFromEducationBodiesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_FundingRemovedFromEducationBodies, applydataHelpers.FundingRemovedFromEducationBodies);
            Continue();
            return new RemovedFromProfessionalOrTradeRegistersPage(_context);
        }
    }
}