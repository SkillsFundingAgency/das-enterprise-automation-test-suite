using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderReserveFundingForNonLevyEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reserve funding for non-levy employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ReserveFundingButton => By.CssSelector(".govuk-button");

        public ProviderReserveFundingForNonLevyEmployersPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderChooseAnEmployerNonLevyPage StartReservedFunding()
        {
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new ProviderChooseAnEmployerNonLevyPage(_context);
        }
    }
}
