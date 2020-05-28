using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourApprenticesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your apprentices";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NoOfApprentices2019 => By.CssSelector("#z0__Answer");
        private By NoOfApprentices2020 => By.CssSelector("#z1__Answer");
        private By NoOfApprentices => By.CssSelector("#z2__Answer");


        public YourApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterApprenticeDetails()
        {
            formCompletionHelper.EnterText(NoOfApprentices2019, dataHelper.NoofApprentices2019);
            formCompletionHelper.EnterText(NoOfApprentices2020, dataHelper.NoofApprentices2020);
            formCompletionHelper.EnterText(NoOfApprentices, dataHelper.NoofNewApprentices);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}