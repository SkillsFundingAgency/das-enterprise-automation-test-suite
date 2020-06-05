using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerStartDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "New training start date";

        private readonly ScenarioContext _context;
        
        private By StartDateMonth => By.Name("StartMonth");
        private By StartDateYear => By.Name("StartYear");

        public ChangeOfEmployerStartDatePage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfEmployerEndDatePage EndNewStartDateAndContinue()
        {
            formCompletionHelper.EnterText(StartDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(StartDateYear, DateTime.UtcNow.Year.ToString());
            Continue();
            return new ChangeOfEmployerEndDatePage(_context);
        }
    }
}
