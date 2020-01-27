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
        private readonly YourOrganisationSectionHelper _yourOrganisationSectionHelper;
        private readonly FinancialEvidenceSectionHelper _financialEvidenceSectionHelper;

        public End2EndStepsHelper(ScenarioContext context)
        {
            _context = context;
            _yourOrganisationSectionHelper = new YourOrganisationSectionHelper();
            _financialEvidenceSectionHelper = new FinancialEvidenceSectionHelper();
        }

        internal TermsConditionsMakingApplicationPage SubmitValidUserDetails()
        {
            return new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectingNoOptionForFirstTimeSignInAndContinue()
                .SubmitValidUserDetails();
        }

        internal EnterUkprnPage AcceptAndContinue(TermsConditionsMakingApplicationPage page) => page.AcceptAndContinue();

        internal ApplicationOverviewPage CompleteProviderRouteSection(EnterUkprnPage enterUkprnPage)
        {
            return enterUkprnPage
                .EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain()
                .VerifyIntroductionStatus(StatusHelper.StatusNext);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteFinancialEvidence(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_1(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_2(applicationOverviewPage);
            applicationOverviewPage = _financialEvidenceSectionHelper.CompleteFinancialEvidence_3(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesCriminalAndComplianceSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesProtectingYourApprenticesSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesReadinessToEngageSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesPlanningApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesDeliveringApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesEvaluatingApprenticeshipTrainingSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompletesFinishSection(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage;
        }
    }
}
