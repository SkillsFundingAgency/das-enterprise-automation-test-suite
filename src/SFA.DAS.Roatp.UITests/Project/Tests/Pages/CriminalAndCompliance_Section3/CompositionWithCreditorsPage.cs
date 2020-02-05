using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class CompositionWithCreditorsPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have any composition with creditors?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_CompositionWithCreditots => By.Id("CC-20.1");

        public CompositionWithCreditorsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PayBackFundsLastThreeYearsPage SelectYesForCompositionWithCreditorsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_CompositionWithCreditots, applydataHelpers.CompositionWithCreditots);
            Continue();
            return new PayBackFundsLastThreeYearsPage(_context);
        }
    }

}
