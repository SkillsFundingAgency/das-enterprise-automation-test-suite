using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderConfirmEmployerNonLevyPage : BasePage
    {
        protected override string PageTitle => "Confirm employer";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmEmployerNonLevyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        internal ProviderApprenticeshipTrainingPage ConfirmNonLevyEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-yes");
            Continue();
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
