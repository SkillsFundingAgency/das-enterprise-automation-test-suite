using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlBankruptInLastThreeYearsPage : RoatpBasePage
    {
        protected override string PageTitle => "partner organisations been made bankrupt in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlBankruptInLastThreeYearsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesEnterInformationForBankruptAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlBankruptInLastThreeYears);
            return new ApplicationOverviewPage(_context);
        }
    }
}
