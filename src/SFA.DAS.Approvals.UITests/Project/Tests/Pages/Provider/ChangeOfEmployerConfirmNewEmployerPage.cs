using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerConfirmNewEmployerPage : ApprovalsBasePage
    {
        private ScenarioContext _context;
        protected override string PageTitle => "Confirm new employer";

        public ChangeOfEmployerConfirmNewEmployerPage(ScenarioContext context) : base(context) => _context = context;
        
        public ChangeOfEmployerStartDatePage ConfirmNewEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            Continue();
            return new ChangeOfEmployerStartDatePage(_context);
        }
    }
}
