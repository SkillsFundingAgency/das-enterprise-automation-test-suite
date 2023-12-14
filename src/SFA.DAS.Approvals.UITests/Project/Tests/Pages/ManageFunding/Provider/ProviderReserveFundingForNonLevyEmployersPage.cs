using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderReserveFundingForNonLevyEmployersPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Reserve funding for non-levy employers";
        private static By ReserveFundingButton => By.LinkText("Reserve funding");

        protected override By AcceptCookieButton => By.CssSelector(".govuk-button");

        internal ProviderChooseAnEmployerNonLevyPage StartReservedFunding()
        {
            AcceptCookies();
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new ProviderChooseAnEmployerNonLevyPage(context);
        }
    }
}
