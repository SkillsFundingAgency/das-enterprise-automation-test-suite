using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class End2EndStepsHelper
    {
        private readonly ScenarioContext _context;

        public End2EndStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        internal TermsConditionsMakingApplicationPage SubmitValidUserDetails()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectingNoOptionForFirstTimeSignInAndContinue()
                .SubmitValidUserDetails();
        }

        internal EnterUkprnPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue();

        internal void CompleteProviderRouteSection(EnterUkprnPage enterUkprnPage)
        {
            enterUkprnPage.EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain()
                .VerifyIntroductionStatus(StatusHelper.StatusNext);
        }
    }
}
