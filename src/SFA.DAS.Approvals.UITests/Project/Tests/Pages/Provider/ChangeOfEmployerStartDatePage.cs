using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerStartDatePage : BasePage
    {
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private By StartDateMonth => By.Name("StartMonth");
        private By StartDateYear => By.Name("StartYear");
        public ChangeOfEmployerStartDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        protected override string PageTitle { get; }

        public ChangeOfEmployerEndDatePage EndNewStartDateAndContinue()
        {
            //VerifyPage();
            _formCompletionHelper.EnterText(StartDateMonth, DateTime.UtcNow.Month.ToString());
            _formCompletionHelper.EnterText(StartDateYear, DateTime.UtcNow.Year.ToString());
            Continue();
            return new ChangeOfEmployerEndDatePage(_context);
        }
    }
}
