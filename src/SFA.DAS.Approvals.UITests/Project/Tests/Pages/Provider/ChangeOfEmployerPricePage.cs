using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerPricePage : BasePage
    {
        private FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private By Price => By.Id("Price");
        public ChangeOfEmployerPricePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        protected override string PageTitle { get; }

        public ChangeOfEmployerSummaryPage EnterNewPriceAndContinue()
        {
            _formCompletionHelper.EnterText(Price, "1002");
            Continue();
            return new ChangeOfEmployerSummaryPage(_context);
        }
    }
}
