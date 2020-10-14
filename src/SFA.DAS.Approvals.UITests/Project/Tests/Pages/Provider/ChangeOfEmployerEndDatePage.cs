using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerEndDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "New training end date";

        private By EndDateMonth => By.Name("EndMonth");
        private By EndDateYear => By.Name("EndYear");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        private readonly ScenarioContext _context;

        public ChangeOfEmployerEndDatePage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfEmployerPricePage EnterNewEndDateAndContinue()
        {
            formCompletionHelper.EnterText(EndDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(EndDateYear, DateTime.UtcNow.AddYears(1).Year.ToString());
            Continue();
            return new ChangeOfEmployerPricePage(_context);
        }
    }
}
