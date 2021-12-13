using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderReserveFundingForNonLevyEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reserve funding for non-levy employers";
        private By ReserveFundingButton => By.LinkText("Reserve funding");

        protected override By AcceptCookieButton => By.CssSelector(".govuk-button");

        public ProviderReserveFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)  { }

        internal ProviderChooseAnEmployerNonLevyPage StartReservedFunding()
        {
            AcceptCookies();
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new ProviderChooseAnEmployerNonLevyPage(context);
        }
    }
}
