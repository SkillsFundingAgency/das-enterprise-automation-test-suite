using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class YourOrganisation_Section1_Helper
    {
        internal ApplicationOverviewPage VerifySection1Status(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .VerifyIntroductionStatus(StatusHelper.StatusCompleted)
                .VerifyOrganisationInformation(StatusHelper.StatusCompleted)
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted)
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted)
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

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

        internal ApplicationOverviewPage CompleteYourOrganisationSection_2_HasWebsite(ApplicationOverviewPage applicationOverviewPage)
        {
            return CompleteYourOrganisationSection_Website_2(applicationOverviewPage
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

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3_CharityAndCompany(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUSWhosInControlSection()
                .ConfirmWhosInContorlAndContinueToTrusteesPage()
                .ConfirmTrusteesAndContinue()
                .EnterDateOfBirth()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3_GovernmentStatue(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUsWhosInControlSectionForCHManualEntryTrue()
                .EnterWhoIsInControlDetailsAndContinue()
                .ConfirmWhosInContorlAndContinue()
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

        internal ApplicationOverviewPage CompleteYourOrganisationSection_3_Supporting_Partnership(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessTellUsWhosInControlSectionForSoleTrader()
                .SelectSoleTraderAndContinue()
                .EnterDateOfBirth()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted)
                .AccessTellUsWhosInControlSectionForSoleTrader()
                .SelectPartnershipAndContinue()
                .SelectOrganisationAndContinue()
                .EnterOrganisationDetailsAndContinue()
                .ConfirmAndContinue()
                .VerifyTellUsWhosInControlStatus(StatusHelper.StatusCompleted)
                .AccessTellUsWhosInControlSectionForSoleTrader()
                .SelectIndividualForPartnershipContinue()
                .AddAnotherPartner()
                .SelectIndividualAndContinue()
                .EnterIndividualsDetailsAndContinue()
                .ConfirmAndContinue()
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

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_SixthFormCollege(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectEducationalInstituteAndContinue()
                .SelectSixthFormCollegeAndContinue()
                .SelectYesForOrgAlreadyRegisteredAndContinueRouteEmployer()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectNoneOfTheAboveAndContinue()
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

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeAEI(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectEducationalInstituteAndContinue()
                .SelectHigherEducationInstituteAndContinue()
                .SelectYesForOrgSupportedandMonitoredByOFSAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeHEIEmplopyerRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectEducationalInstituteAndContinue()
                .SelectHigherEducationInstituteAndContinue()
                .SelectYesForOrgSupportedandMonitoredByOFSAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeAcadamy(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectEducationalInstituteAndContinue()
                .SelectAcademyAndContinue()
                .SelectYesForOrgAlreadyRegisteredAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypeATP(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessDescribeYourOrganisationsForOrgTypeCharity()
                .SelectAnApprenticeshipTrainingAgencyAndContinue()
                .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_4_OrgTypePublicBody(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessDescribeYourOrganisationsForOrgTypeCharity()
                    .SelectPublicBodyAndContinue()
                    .SelectGovernmentDepartmentAndContinue()
                    .SelectPublicServiceMutalAndShelterdWorkshopAndContinue()
                    .VerifyDescribeYourOrganisationStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_NoToAllMainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectNoForFundedbyOFSAndContinue()
                .SelectNoForITTAndContinue()
                .SelectNoForFullOfstedInspectionAndContinue()
                .SelectNoForMonitoringVisitAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_NoToAllForEmployerRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectNoForITTAndContinue()
                .SelectNoForFullOfstedInspectionAndContinue()
                .SelectNoForMonitoringVisitAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_Support(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .AccessExperienceAndAccreditationsSectionForSupportingRoute()
                .SelectYesForOrgDeliveredApprenticeshipTrainingAsSubcontractor()
                .UploadLegallyBindingContractAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_GradeTypeRequiresImprovement(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecRequiresImprovementAndContinue()
                .SelectForoverallEffectivenessGradeRequiresImprovementAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_GradeOutstanding(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectNoForGradeWithinThreeYearsAndContinue()
                .SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_YesToPGTA(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForMainRoute()
               .SelectYesForFundedbyOFSAndContinue()
               .SelectYesForITTAndContinue()
               .SelectYesForPGTAAndContinue()
               .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage CompleteYourOrganisationSection_5_Ofsted(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectYesForGradeWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
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

        private ApplicationOverviewPage CompleteYourOrganisationSection_Website_2(IcoRegistrationNumberPage icoRegistrationNumberPage)
        {
            return icoRegistrationNumberPage
                .EnterIcoRegistrationNumber_WebsiteAndContinue()
                .SelectMaximumTradingPeriodAndContinue()
                .VerifyOrganisationInformation(StatusHelper.StatusCompleted);
        }

        internal ApplicationOverviewPage UnhappyPathJourney_YourOrganisationSection_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessYourOrganisationSectionForOrgTypeCompany()
                .SelectYesForUltimateParentCompanyAndContinue()
                .EnterParentCompanyDetailsAndContinue()
                .EnterIcoRegistrationNumberAndContinue()
                .EneterWebsiteAndContinue()
                .SelectMinimumTradingPeriodAndContinue()
                .ReturnToApplicationOverview()
                .VerifyOrganisationInformation(StatusHelper.StatusInProgress);
        }

        internal ApplicationOverviewPage UnhappyPathJourney_YourOrganisationSection_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectNoForFundedbyOFSAndContinue()
                .SelectNoForITTAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecInadequateAndContinue()
                .SelectYesForInadequateGradeWithinThreeYearsAndContinue()
                .ReturnToApplicationOverview()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusInProgress)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectNoForFundedbyOFSAndContinue()
                .SelectNoForITTAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectNoForGradeInFullOfstedInspectionAndContinue()
                .SelectForoverallEffectivenessGradeInadequateAndContinue()
                .SelectYesForInadequateGradeWithinThreeYearsAndContinue()
                .ReturnToApplicationOverview()
                .VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusInProgress);
        }

        internal ApplicationOverviewPage CompleteAndVerifySectionExemptions_MainRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .ReturnToApplicationOverview()
                .Verify_Section4(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectYesForPGTAAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectYesForGradeWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectNoForGradeWithinThreeYearsAndContinue()
                .SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectNoForGradeInFullOfstedInspectionAndContinue()
                .SelectForoverallEffectivenessGradeGoodAndContinue()
                .SelectYesForGradeWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForMainRoute()
                .SelectYesForFundedbyOFSAndContinue()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectNoForGradeInFullOfstedInspectionAndContinue()
                .SelectForoverallEffectivenessGradeOutstandingAndContinue()
                .SelectNoForGradeWithinThreeYearsAndContinue()
                .SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired);
        }

        internal ApplicationOverviewPage CompleteAndVerifySectionExemptions_EmployerRoute(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectYesForPGTAAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectYesForGradeWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectYesForGradeInFullOfstedInspectionAndContinue()
                .SelecOutstandingAndContinue()
                .SelectNoForGradeWithinThreeYearsAndContinue()
                .SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyQualityAndHighStandards_Section7(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .VerifyQualityOfTheTrainingDeleivered_Section8(StatusHelper.NotRequired)
                .VerifyQualityOfTheTraining_Section8(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectNoForGradeInFullOfstedInspectionAndContinue()
                .SelectForoverallEffectivenessGradeGoodAndContinue()
                .SelectYesForGradeWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired)
                .AccessExperienceAndAccreditationsSectionForEmployerRoute()
                .SelectYesForITTAndContinue()
                .SelectNoForPGTAAndContinue()
                .SelectYesForFullOfstedInspectionAndContinue()
                .SelectNoForGradeInFullOfstedInspectionAndContinue()
                .SelectForoverallEffectivenessGradeOutstandingAndContinue()
                .SelectNoForGradeWithinThreeYearsAndContinue()
                .SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
                .SelectYesForGradeMaintainedAndContinue()
                .SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
                .Verify_Section4(StatusHelper.NotRequired)
                .VerifyDevelopingAndDelivering_Section7(StatusHelper.NotRequired);
        }
    }
}
