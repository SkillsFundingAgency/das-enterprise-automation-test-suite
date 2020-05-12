using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerEndDatePage : BasePage
    {
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private By EndDateMonth => By.Name("EndMonth");
        private By EndDateYear => By.Name("EndYear");
        public ChangeOfEmployerEndDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        protected override string PageTitle { get; }

        public ChangeOfEmployerPricePage EnterNewEndDateAndContinue()
        {
            _formCompletionHelper.EnterText(EndDateMonth, DateTime.UtcNow.Month.ToString());
            _formCompletionHelper.EnterText(EndDateYear, DateTime.UtcNow.Year.ToString());
            Continue();
            return new ChangeOfEmployerPricePage(_context);
        }
    }
}
