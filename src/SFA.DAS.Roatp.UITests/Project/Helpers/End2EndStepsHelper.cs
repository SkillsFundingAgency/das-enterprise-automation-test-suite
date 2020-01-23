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

        internal ApplicationOverviewPage CompleteProviderRouteSection(EnterUkprnPage enterUkprnPage)
        {
            return enterUkprnPage.EnterOrgTypeCompanyProvidersUkprn()
                .ClickConfirmAndContinue()
                .SelectApplicationRouteAsMain()
                .VerifyIntroductionStatus(StatusHelper.StatusNext);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection(ApplicationOverviewPage applicationOverviewPage)
        {
            applicationOverviewPage = CompleteYourOrganisationSection_1(applicationOverviewPage);
            applicationOverviewPage = CompleteYourOrganisationSection_2(applicationOverviewPage);
            applicationOverviewPage = CompleteYourOrganisationSection_3(applicationOverviewPage);
            applicationOverviewPage = CompleteYourOrganisationSection_4(applicationOverviewPage);
            applicationOverviewPage = CompleteYourOrganisationSection_5(applicationOverviewPage);
            return applicationOverviewPage;
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessIntroductionWhatYouWillNeedSection()
                .VerifyIntorductionForMainAndEmployerAndContinue()
                .VerifyIntroductionStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessYourOrganisationSectionForOrgTypeCompany()
                .SelectYesForUltimateParentCompanyAndContinue()
                .EnterParentCompanyDetailsAndContinue()
                .EnterIcoRegistrationNumberAndContinue()
                .EneterWebsiteAndContinue()
                .SelectMaximumTradingPeriodAndContinue()
                .VerifyOrganisationInformation(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessTellUSWhosInControlSection()
                .ConfirmWhosInContorlAndContinue()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectIndependentTrainingProviderAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSection()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectNoForITTAndContinue()
                .SelectNoForFullOfstedInspectionAndContinue()
                .SelectNoForMonitoringVisitAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }
    }
}
