using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderConfirmEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmEmployerNonLevyPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApprenticeshipTrainingPage ConfirmNonLevyEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            Continue();
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
