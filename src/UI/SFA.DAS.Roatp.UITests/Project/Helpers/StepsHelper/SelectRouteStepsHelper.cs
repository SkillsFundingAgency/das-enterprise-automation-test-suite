using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class SelectRouteStepsHelper(ScenarioContext context)
    {
        internal NotAcceptTermsConditionsPage DoNotAcceptTermsConditions() => ConfirmUkprn().SelectApplicationRouteAsMain().DoNotAcceptTermsConditions();
        public ApplicationOverviewPage CompleteProviderMainRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsMain());
        internal ApplicationOverviewPage CompleteProviderCharityRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsEmployer().SelectYesForLevyPayingEmployerAndContinue());
        internal ApplicationOverviewPage CompleteProviderEmployerRouteSection_ExistingProvider() => ConfirmUkprnForProviderOnRoatp().SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsEmployer().SelectYesForLevyPayingEmployerAndContinue().AcceptTermAndConditionsAndContinue();
        internal ApplicationOverviewPage CompleteProviderSupportingRouteSection_ExistingProvider() => ConfirmUkprnForProviderOnRoatp().SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsSupporting().AcceptTermAndConditionsAndContinue();
        internal ApplicationOverviewPage CompleteProviderMainRouteSection_ExistingProvider() => ConfirmUkprnForProviderOnRoatp().SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsMain().AcceptTermAndConditionsAndContinue();
        internal AlreadyOnRoatpPage CompleteProviderCharityRouteWhoisAlreayOnRoatp() => ConfirmUkprnForProviderOnRoatp();
        internal ApplicationOverviewPage CompleteProviderSupportRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsSupporting());
        internal static ApplicationOverviewPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptTermAndConditionsAndContinue().VerifyIntroductionStatus(StatusHelper.StatusNext);
        private ChooseProviderRoutePage ConfirmUkprn() => ConfirmOrganisationsDetailsPage().ClickConfirmAndContinue();
        private AlreadyOnRoatpPage ConfirmUkprnForProviderOnRoatp() => ConfirmOrganisationsDetailsPage().ClickConfirmAndContinueForProviderOnRoatp();
        private ConfirmOrganisationsDetailsPage ConfirmOrganisationsDetailsPage()
        {
            new RoatpApplyLoginHelpers(context).SubmitValidUserDetails();

            return new EnterUkprnPage(context).EnterOrgTypeCompanyProvidersUkprn();
        }
    }
}