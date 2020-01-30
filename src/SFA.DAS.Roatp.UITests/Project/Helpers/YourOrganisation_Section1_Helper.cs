using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class YourOrganisation_Section1_Helper
    {
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
