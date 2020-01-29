using SFA.DAS.Roatp.UITests.Project.Tests.Pages;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ReadinessToEngage_Section5_Helper
    {
        internal ApplicationOverviewPage CompleteReadinessToEngage_1(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_IntroductionWhatYouwillNeed()
                .ClickSaveAndContinue()
                .VerifyIntroductionStatus_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_2(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_EngagingWithEmployers()
                .ClickYesToEngagedWithEmployersToDeliverApprenticeshipAndContinue()
                .EnterTextForManagingRelationshipWithEmployersAndContinue()
                .EnterDetailsOfIndividualForManagingRelationshipsWithEmployersAndContinue()
                .EnterTextRegardingOrganisationPromoteApprenticeshipsToEmployerAndContinue()
                .VerifyEngaging_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_3(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_section5_ComplaintsPolicy()
                .CompliantsPolicyFileUploadAndContinue()
                .EnterWebsitelinkandContinue()
                .VerifyComplaints_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_4(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_ContractForservicesTemplate()
                .ContractForServicesTemplateFileUploadAndContinue()
                .VerifyContract_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_5(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_CommitmentStatementTemplate()
                .OrganisationsCommitmentStatementTemplateFileUploadAndContinue()
                .VerifyCommitment_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_6(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_PriorLearningOfApprentices()
                .EnterTextRegardingOrganisationProcessForInitialTraningAndContinue()
                .EnterTextRegardingProcessToAssessEnglishAndMathsAndContinue()
                .VerifyPriorLearning_Section5(StatusHelper.StatusCompleted);
        }
        internal ApplicationOverviewPage CompleteReadinessToEngage_7(ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage.Access_Section5_WorkingWithSubContractors()
                .YesToUsingSubcontractorsAndContinue()
                .EnterTextForManagingRelationshipWithEmployersAndContinue()
                .VerifyWorkingWithSubcontractors_Section5(StatusHelper.StatusCompleted);
        }
    }
}
