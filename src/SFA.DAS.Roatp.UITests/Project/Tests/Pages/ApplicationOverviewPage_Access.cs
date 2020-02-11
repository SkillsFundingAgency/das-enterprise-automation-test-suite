using SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.EvaluatingApprenticeshipTraining_Section8;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.Finish_Section9;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.ProtectingYourApprentices_Section4;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.ReadinessToEngage_Section5;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        #region Section9

        public PermissionsFromEveryoneNamedPage Access_Section9_ApplicationPermissionChecks()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Finish, Finish_1));
            return new PermissionsFromEveryoneNamedPage(_context);
        }
        public CommercialInConfidenceInformationPage Access_Section9_CommercialInConfidenceInformation()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Finish, Finish_2));
            return new CommercialInConfidenceInformationPage(_context);
        }
        public TermsAndConditionsSubmittingApplicationPage Access_Section9_TermsAndConditions()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Finish, Finish_3));
            return new TermsAndConditionsSubmittingApplicationPage(_context);
        }
        public SubmitApplicationPage Access_Section9_SubmitApplication()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Finish, Finish_4));
            return new SubmitApplicationPage(_context);
        }

        #endregion


        #region Section8

        public EvaluatingApprenticeshipTrainingPage Access_Section8_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_1));
            return new EvaluatingApprenticeshipTrainingPage(_context);
        }
        public ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage Access_Section8_ProcessForEvaluatingTheQualityOfTrainingDelivered()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_2));
            return new ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage(_context);
        }
        public ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage Access_Section8_ProcessForEvaluatingTheQualityOfApprenticeshipTraining()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_3));
            return new ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage(_context);
        }
        public SystemsAndProcessesToCollectApprenticeshipDataPage Access_Section8_SystemsAndProcessesToCollectApprenticeshipDataForMainAndEmpoyerRoute()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_4));
            return new SystemsAndProcessesToCollectApprenticeshipDataPage(_context);
        }

        #endregion

        #region Section7

        public DeliveringApprenticeshipTrainingPage Access_Section7_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_1));
            return new DeliveringApprenticeshipTrainingPage(_context);
        }

        #endregion

        #region Section6

        public PlanningApprenticeshipTrainingPage Access_Section6_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_1));
            return new PlanningApprenticeshipTrainingPage(_context);
        }

        public TypeOfApprenticeshipTrainingPage Access_Section6_TypeOfApprenticeshipTraining()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_2));
            return new TypeOfApprenticeshipTrainingPage(_context);
        }

        public EnsureApprenticesSupportedPage Access_Section6_SupportingApprentices()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_3));
            return new EnsureApprenticesSupportedPage(_context);
        }

        public ForecastInFirst12MonthsPage Access_Section6_ForeCastingStarts()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_4));
            return new ForecastInFirst12MonthsPage(_context);
        }
        public WhatTeachingMethodsPage Access_Section6_OffTheJobTraining()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_5));
            return new WhatTeachingMethodsPage(_context);
        }
        public WhereWillApprenticesBeTrainedPage Access_Section6_WhereWillYourApprenticesBeTrained()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_6));
            return new WhereWillApprenticesBeTrainedPage(_context);
        }
        #endregion


        #region Section5
        public ReadinessToEngagePage Access_Section5_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_1));
            return new ReadinessToEngagePage(_context);
        }
        public OrganisationEngagedWithEmployersToDeliverApprenticeshipPage Access_Section5_EngagingWithEmployers()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_2));
            return new OrganisationEngagedWithEmployersToDeliverApprenticeshipPage(_context);
        }
        public UploadCompliantsPolicyPage Access_section5_ComplaintsPolicy()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_3));
            return new UploadCompliantsPolicyPage(_context);
        }
        public UploadContractForServiceTemplatePage Access_Section5_ContractForservicesTemplate()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_4));
            return new UploadContractForServiceTemplatePage(_context);
        }
        public UploadCommitmentStatementTemplatePage Access_Section5_CommitmentStatementTemplate()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_5));
            return new UploadCommitmentStatementTemplatePage(_context);
        }
        public OrganisationsProcessForInitialAssessementsPage Access_Section5_PriorLearningOfApprentices()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_6));
            return new OrganisationsProcessForInitialAssessementsPage(_context);
        }
        public OrganisationExpectToUseSubcontractorsPage Access_Section5_WorkingWithSubContractors()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ReadinessToEngage, ReadinessToEngage_7));
            return new OrganisationExpectToUseSubcontractorsPage(_context);
        }
        #endregion

        #region Section4

        public ProtectingYourApprenticesPage Access_Section4_IntroductionWhatYouWillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ProtectingYourApprentices, ProtectingYourApprentices_1));
            return new ProtectingYourApprenticesPage(_context);
        }
        public ContinuityPlanForApprenticeshipTrainingPage Access_Section4_ContinuityPlanForApprenticeshipTraining()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ProtectingYourApprentices, ProtectingYourApprentices_2));
            return new ContinuityPlanForApprenticeshipTrainingPage(_context);
        }
        public EqualityAndDiversityPolicyPage Access_Section4_EqualityAndDiversityPolicy()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ProtectingYourApprentices, ProtectingYourApprentices_3));
            return new EqualityAndDiversityPolicyPage(_context);
        }
        public SafeguardingPolicyPage Access_Section4_SafeguardingPolicy()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ProtectingYourApprentices, ProtectingYourApprentices_4));
            return new SafeguardingPolicyPage(_context);
        }
        public HealthAndSafetyPolicyPage Access_Section4_HealthAndSafetyPolicy()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(ProtectingYourApprentices, ProtectingYourApprentices_5));
            return new HealthAndSafetyPolicyPage(_context);
        }
        #endregion


        #region Section3

        public CriminalAndComplianceChecksPage Access_Section3_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(CriminalAndComplianceChecks, CriminalAndComplianceChecks_1));
            return new CriminalAndComplianceChecksPage(_context);
        }

        public CompositionWithCreditorsPage Access_Section3_ChecksOnYourOrganisation()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(CriminalAndComplianceChecks, CriminalAndComplianceChecks_2));
            return new CompositionWithCreditorsPage(_context);
        }
        public WhosInControlCriminalAndComplianceChecksPage Access_Section3_IntroductionWhatYouWillNeedStatusWhosInControl()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(CriminalAndComplianceChecks, CriminalAndComplianceChecks_3));
            return new WhosInControlCriminalAndComplianceChecksPage(_context);
        }
        public WhosInControlUnspentCriminalConvictionsPage Access_Section3_ChecksOnWhosInControlOfYourOrganisation()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(CriminalAndComplianceChecks, CriminalAndComplianceChecks_4));
            return new WhosInControlUnspentCriminalConvictionsPage(_context);
        }

        #endregion

        #region Section2

        public FinancialHealthAssessmentPage Access_Section2_IntroductionWhatYouwillNeed()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_1));
            return new FinancialHealthAssessmentPage(_context);
        }

        public AnnualTurnoverPage Access_Section2_YourOrganisationsFinancialEvidence()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_2));
            return new AnnualTurnoverPage(_context);
        }

        public ConsolidatedFinancialStatementsPage Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(FinancialEvidence, FinancialEvidence_3));
            return new ConsolidatedFinancialStatementsPage(_context);
        }

        #endregion

        #region Seciton1

        public YourOrganisationPage AccessIntroductionWhatYouWillNeedSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_1));
            return new YourOrganisationPage(_context);
        }

        public UltimateParentCompanyPage AccessYourOrganisationSectionForOrgTypeCompany()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_2));
            return new UltimateParentCompanyPage(_context);
        }
        public IcoRegistrationNumberPage AccessYourOrganisationSectionForOrgTypeNotACompany()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_2));
            return new IcoRegistrationNumberPage(_context);
        }
        public ConfrimWhosInControlPage AccessTellUSWhosInControlSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_3));
            return new ConfrimWhosInControlPage(_context);
        }
        public ConfirmTrusteesPage AccessTellUSWhosInControlSectionForOrgTypeCharity()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_3));
            return new ConfirmTrusteesPage(_context);
        }
        public OrganisationTypePage AccessTellUsWhosInControlSectionForSoleTrader()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_3));
            return new OrganisationTypePage(_context);
        }
        public WhatIsYourOrganisationPage AccessDescribeYourOrganisationsForOrgTypeCharity()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_4));
            return new WhatIsYourOrganisationPage(_context);
        }
        public FundedByTheOfficeForStudentsPage AccessExperienceAndAccreditationsSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_5));
            return new FundedByTheOfficeForStudentsPage(_context);
        }
        #endregion
    }
}


