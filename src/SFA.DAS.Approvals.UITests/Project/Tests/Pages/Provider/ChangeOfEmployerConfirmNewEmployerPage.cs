using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerConfirmNewEmployerPage : BasePage
    {
        private ScenarioContext _context;
        public ChangeOfEmployerConfirmNewEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        protected override string PageTitle { get; }

        public ChangeOfEmployerStartDatePage ConfirmNewEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            Continue();
            return new ChangeOfEmployerStartDatePage(_context);
        }
    }
}
