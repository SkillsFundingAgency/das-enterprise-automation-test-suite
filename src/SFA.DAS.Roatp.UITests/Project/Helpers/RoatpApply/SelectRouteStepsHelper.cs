using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply
{
    public class SelectRouteStepsHelper
    {
        private readonly ScenarioContext _context;

        public SelectRouteStepsHelper(ScenarioContext context) => _context = context;

        internal NotAcceptTermsConditionsPage DoNotAcceptTermsConditions() => ConfirmUkprn().SelectApplicationRouteAsMain().DoNotAcceptTermsConditions();

        public ApplicationOverviewPage CompleteProviderMainRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsMain());

        internal ApplicationOverviewPage CompleteProviderCharityRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsEmployer().SelectYesForLevyPayingEmployerAndContinue());

        internal AlreadyOnRoatpPage CompleteProviderCharityRouteWhoisAlreayOnRoatp() => ConfirmUkprnForProviderOnRoatp();

        internal ApplicationOverviewPage CompleteProviderSupportRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsSupporting());

        private ChooseProviderRoutePage ConfirmUkprn() => ConfirmOrganisationsDetailsPage().ClickConfirmAndContinue();

        private AlreadyOnRoatpPage ConfirmUkprnForProviderOnRoatp() => ConfirmOrganisationsDetailsPage().ClickConfirmAndContinueForProviderOnRoatp();

        private ConfirmOrganisationsDetailsPage ConfirmOrganisationsDetailsPage()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectOptionToSignInToASAccountAndContinue()
                .SubmitValidUserDetails()
                .EnterOrgTypeCompanyProvidersUkprn();
        }

        private ApplicationOverviewPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue().VerifyIntroductionStatus(StatusHelper.StatusNext);
    }
}