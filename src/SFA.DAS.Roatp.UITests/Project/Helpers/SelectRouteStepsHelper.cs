using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class SelectRouteStepsHelper
    {
        private readonly ScenarioContext _context;

        public SelectRouteStepsHelper(ScenarioContext context) => _context = context;

        internal NotAcceptTermsConditionsPage DoNotAcceptTermsConditions() => ConfirmUkprn().SelectApplicationRouteAsMain().DoNotAcceptTermsConditions();

        internal ApplicationOverviewPage CompleteProviderMainRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsMain());

        internal ApplicationOverviewPage CompleteProviderCharityRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsEmployer().SelectYesForLevyPayingEmployerAndContinue());

        internal ApplicationOverviewPage CompleteProviderSupportRouteSection() => AcceptAndContinue(ConfirmUkprn().SelectApplicationRouteAsSupporting());

        private ChooseProviderRoutePage ConfirmUkprn()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectingNoOptionForFirstTimeSignInAndContinue()
                .SubmitValidUserDetails()
                .EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue();
        }

        private ApplicationOverviewPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue().VerifyIntroductionStatus(StatusHelper.StatusNext);
    }
}