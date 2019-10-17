using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderReserveFundingForNonLevyEmployersPage : BasePage
    {
        protected override string PageTitle => "Reserve funding for non-levy employers";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ReserveFundingButton => By.CssSelector(".govuk-button");

        public ProviderReserveFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderChooseAnEmployerNonLevyPage StartReservedFunding()
        {
            _formCompletionHelper.ClickElement(ReserveFundingButton);
            return new ProviderChooseAnEmployerNonLevyPage(_context);
        }
    }
}
