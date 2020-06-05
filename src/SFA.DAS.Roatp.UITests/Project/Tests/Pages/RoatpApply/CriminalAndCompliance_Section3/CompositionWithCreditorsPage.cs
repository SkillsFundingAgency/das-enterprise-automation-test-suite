using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class CompositionWithCreditorsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have any composition with creditors?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CompositionWithCreditorsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PayBackFundsLastThreeYearsPage SelectYesForCompositionWithCreditorsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.CompositionWithCreditots);
            return new PayBackFundsLastThreeYearsPage(_context);
        }
    }

}
