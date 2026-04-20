using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderYourFundingReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your funding reservation";

        #region Helpers and Context
        private readonly string _reservationId;
        #endregion

        protected By AddLearnerLink => By.CssSelector($"table a[href*='?reservationId={_reservationId}']");

        protected By DeleteFundingLink => By.CssSelector($"table a[href*='{_reservationId}/delete']");

        private static By NextPageLink => By.XPath("//a[contains(text(),'Next')]");

        protected static By ReserveMoreFundingLink => By.LinkText("Reserve more funding");

        public ProviderYourFundingReservationPage(ScenarioContext context) : base(context) => _reservationId = objectContext.GetReservationId();

        internal ProviderAddApprenticeDetailsHow AddApprenticeWithReservedFunding()
        {
            SearchForAnyReservation();
            formCompletionHelper.ClickElement(AddLearnerLink);
            return new ProviderAddApprenticeDetailsHow(context);
        }

        public ProviderAccessDeniedPage AddApprenticeWithReservedFundingGoesToAccessDenied()
        {
            SearchForAnyReservation();
            formCompletionHelper.ClickElement(AddLearnerLink);
            return new ProviderAccessDeniedPage(context);
        }

        internal DeleteReservationPage DeleteTheReservedFunding()
        {
            SearchForAnyReservation();
            formCompletionHelper.ClickElement(DeleteFundingLink);
            return new DeleteReservationPage(context);
        }

        public ProviderAccessDeniedPage DeleteTheReservedFundingGoesToAccessDenied()
        {
            SearchForAnyReservation();
            formCompletionHelper.ClickElement(DeleteFundingLink);
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderYourFundingReservationPage VerifyReservationExists()
        {
            SearchForAnyReservation();
            VerifyElement(() => pageInteractionHelper.FindElement(DeleteFundingLink), "Delete", null);
            return this;
        }

        public ProviderReserveFundingForNonLevyEmployersPage ClickReserveMoreFundingLink()
        {
            formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ProviderReserveFundingForNonLevyEmployersPage(context);
        }

        public ProviderAccessDeniedPage ClickReserveMoreFundingLinkGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ProviderAccessDeniedPage(context);
        }

        private void SearchForAnyReservation()
        {
            do
            {
                if (pageInteractionHelper.IsElementDisplayed(AddLearnerLink))
                    break;

                if (pageInteractionHelper.IsElementDisplayed(NextPageLink))
                {
                    formCompletionHelper.ClickElement(NextPageLink);
                }
                else
                {
                    break;
                }
            }
            while (true);

            VerifyElement(AddLearnerLink);
        }
    }
}