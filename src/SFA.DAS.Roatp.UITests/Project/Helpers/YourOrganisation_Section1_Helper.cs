using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class YourOrganisation_Section1_Helper
    {
        internal ApplicationOverviewPage CompleteYourOrganisationSection_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessIntroductionWhatYouWillNeedSection()
                .VerifyIntroductionAndContinue()
                .VerifyIntroductionStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_1_SupportRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessIntroductionWhatYouWillNeedSection()
                .VerifyIntroductionForSupportingAndContinue()
                .VerifyIntroductionStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_2_NotACompany(ApplicationOverviewPage applicationOverviewPage)
        {
            return CompleteYourOrganisationSection_2(applicationOverviewPage
               .AccessYourOrganisationSectionForOrgTypeNotACompany());  
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return CompleteYourOrganisationSection_2(applicationOverviewPage
                .AccessYourOrganisationSectionForOrgTypeCompany()
                .SelectYesForUltimateParentCompanyAndContinue()
                .EnterParentCompanyDetailsAndContinue());
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUSWhosInControlSection()
                .ConfirmWhosInContorlAndContinue()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3_Charity(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUSWhosInControlSectionForOrgTypeCharity()
                .ConfirmTrusteesAndContinue()
                .EnterDateOfBirth()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3_Support(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUsWhosInControlSectionForSoleTrader()
                .SelectSoleTraderAndContinue()
                .EnterDateOfBirth()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectIndependentTrainingProviderAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }
        
        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectNoneOfTheAboveAndContinue()
                .SelectInYourOrganisationAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeGTA(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectGroupTrainingAssociationAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_NoToAll(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessExperienceAndAccreditationsSection()
                .SelectNoForFundedbyOFSAndContinue()
                .SelectNoForITTAndContinue()
                .SelectNoForFullOfstedInspectionAndContinue()
                .SelectNoForMonitoringVisitAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_Support(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessExperienceAndAccreditationsSection()
                .SelectNoForFundedbyOFSAndContinueForSupportingRoute()
                .SelectYesForOrgDeliveredApprenticeshipTrainingAsSubcontractor()
                .UploadLegallyBindingContractAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        private ApplicationOverviewPage CompleteYourOrganisationSection_2(IcoRegistrationNumberPage icoRegistrationNumberPage)
        {
            return icoRegistrationNumberPage
                .EnterIcoRegistrationNumberAndContinue()
                .EneterWebsiteAndContinue()
                .SelectMaximumTradingPeriodAndContinue()
                .VerifyOrganisationInformation(StatusHelper.StatusCompleted);
        }
    }
}
