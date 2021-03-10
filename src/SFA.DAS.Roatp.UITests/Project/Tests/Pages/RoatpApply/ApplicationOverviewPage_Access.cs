using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6;
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1;
namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public partial class ApplicationOverviewPage : RoatpApplyBasePage
    {
        private By ChangeUkprn => By.CssSelector("a[href*='change-ukprn?']");

        private By ChangeRoute => By.CssSelector("a[href*='ChangeRoute?']");

        #region Section9

        private void NavigateToTask(string sectionName, string taskName, int index = 0) => formCompletionHelper.ClickElement(GetTaskLinkElement(sectionName, taskName, index), () => formCompletionHelper.ClickLinkByText("Application overview"));

        public ChangeUkprnPage Access_ChangeUkprn()
        {
            formCompletionHelper.ClickElement(ChangeUkprn);
            return new ChangeUkprnPage(_context);
        }
        public ChangeRoutePage Access_ChangeRoute()
        {
            formCompletionHelper.ClickElement(ChangeRoute);
            return new ChangeRoutePage(_context);
        }

        public PermissionsFromEveryoneNamedPage Access_Section9_ApplicationPermissionChecks()
        {
            NavigateToTask(Finish, Finish_1);
            return new PermissionsFromEveryoneNamedPage(_context);
        }
        public InLineWithInstituteForApprenticeshipPage Access_Section9_QualityStatement()
        {
            NavigateToTask(Finish, Finish_2);
            return new InLineWithInstituteForApprenticeshipPage(_context);
        }
        public CompletesAllPostApplicationTasksPage Access_Section9_PostApplicationTasks()
        {
            NavigateToTask(Finish, Finish_3);
            return new CompletesAllPostApplicationTasksPage(_context);
        }
        public SubmitApplicationPage Access_Section9_SubmitApplication()
        {
            NavigateToTask(Finish, Finish_4);
            return new SubmitApplicationPage(_context);
        }

        #endregion

        #region Section8

        public EvaluatingApprenticeshipTrainingPage Access_Section8_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_1);
            return new EvaluatingApprenticeshipTrainingPage(_context);
        }
        public ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage Access_Section8_ProcessForEvaluatingTheQualityOfTrainingDelivered()
        {
            NavigateToTask(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_2);
            return new ProcessOfEvaluatingTheQualityOfTrainingDeliveredPage(_context);
        }
        public ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage Access_Section8_ProcessForEvaluatingTheQualityOfApprenticeshipTraining()
        {
            NavigateToTask(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_3);
            return new ProcessOfEvaluatingTheQualityOfApprenticshipTrainingPage(_context);
        }
        public SystemsAndProcessesToCollectApprenticeshipDataPage Access_Section8_SystemsAndProcessesToCollectApprenticeshipDataForMainAndEmpoyerRoute()
        {
            NavigateToTask(EvaluatingApprenticeshipTraining, EvaluatingApprenticeshipTraining_4);
            return new SystemsAndProcessesToCollectApprenticeshipDataPage(_context);
        }

        #endregion

        #region Section7

        public DeliveringApprenticeshipTrainingPage Access_Section7_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_1);
            return new DeliveringApprenticeshipTrainingPage(_context);
        }

        public TellUsWhoHasOverallAccountabilityPage Access_Section7_OverallAccountability()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_2);
            return new TellUsWhoHasOverallAccountabilityPage(_context);
        }

        public OrganisationManagementHierarchyPage Access_Section7_ManagementHierarchy()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_3);
            return new OrganisationManagementHierarchyPage(_context);
        }

        public UploadManagementExpectationsForQualitypage Access_Section7_QualityAndHighStandards()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_4);
            return new UploadManagementExpectationsForQualitypage(_context);
        }
        public DoesYourOrganisationHaveATeamPage  Access_Section7_DevelopingAndDelivering()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_5);
            return new DoesYourOrganisationHaveATeamPage(_context);
        }
        public DoesYourOrganisationHaveSomeonePage Access_Section7_DevelopingAndDelivering_Support()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_5);
            return new DoesYourOrganisationHaveSomeonePage(_context);
        }
        public YourSectorsAndEmployeesPage Access_Section7_YourSectorsAndEmployees()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_6);
            return new YourSectorsAndEmployeesPage(_context);
        }
        public UploadOrganisationPolicyPage Access_Section7_PolicyForProfessionalDevelopment()
        {
            NavigateToTask(DeliveringApprenticeshipTraining, DeliveringApprenticeshipTraining_7);
            return new UploadOrganisationPolicyPage(_context);
        }
        

        #endregion

        #region Section6 

        public PlanningApprenticeshipTrainingPage Access_Section6_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_1);
            return new PlanningApprenticeshipTrainingPage(_context);
        }

        public TypeOfApprenticeshipTrainingPage Access_Section6_TypeOfApprenticeshipTraining()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_2);
            return new TypeOfApprenticeshipTrainingPage(_context);
        }

        public TrainApprenticesPage Access_Section6_TrainingApprentices()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_3);
            return new TrainApprenticesPage(_context);
        } 

        public EnsureApprenticesSupportedPage Access_Section6_SupportingApprentices()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_4);
            return new EnsureApprenticesSupportedPage(_context);
        }
      
        public ForecastInFirst12MonthsPage Access_Section6_ForeCastingStarts()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_5);
            return new ForecastInFirst12MonthsPage(_context);
        }
        public WhatTeachingMethodsPage Access_Section6_OffTheJobTraining()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_6);
            return new WhatTeachingMethodsPage(_context);
        }
        public WhereWillApprenticesBeTrainedPage Access_Section6_WhereWillYourApprenticesBeTrained()
        {
            NavigateToTask(PlanningApprenticeshipTraining, PlanningApprenticeshipTraining_7);
            return new WhereWillApprenticesBeTrainedPage(_context);
        }
        #endregion


        #region Section5
        public ReadinessToEngagePage Access_Section5_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_1);
            return new ReadinessToEngagePage(_context);
        }
        public OrganisationEngagedWithEmployersToDeliverApprenticeshipPage Access_Section5_EngagingWithEmployers()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_2);
            return new OrganisationEngagedWithEmployersToDeliverApprenticeshipPage(_context);
        }
        public UploadCompliantsPolicyPage Access_section5_ComplaintsPolicy()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_3);
            return new UploadCompliantsPolicyPage(_context);
        }
        public UploadContractForServiceTemplatePage Access_Section5_ContractForservicesTemplate()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_4);
            return new UploadContractForServiceTemplatePage(_context);
        }
        public CommitmentStatementTemplatePage Access_Section5_CommitmentStatementTemplate()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_5);
            return new CommitmentStatementTemplatePage(_context);
        }
        public OrganisationsProcessForInitialAssessementsPage Access_Section5_PriorLearningOfApprentices()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_6);
            return new OrganisationsProcessForInitialAssessementsPage(_context);
        }
        public OrganisationExpectToUseSubcontractorsPage Access_Section5_WorkingWithSubContractors()
        {
            NavigateToTask(ReadinessToEngage, ReadinessToEngage_7);
            return new OrganisationExpectToUseSubcontractorsPage(_context);
        }
        #endregion

        #region Section4

        public ProtectingYourApprenticesPage Access_Section4_IntroductionWhatYouWillNeed()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_1);
            return new ProtectingYourApprenticesPage(_context);
        }
        public ContinuityPlanForApprenticeshipTrainingPage Access_Section4_ContinuityPlanForApprenticeshipTraining()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_2);
            return new ContinuityPlanForApprenticeshipTrainingPage(_context);
        }
        public EqualityAndDiversityPolicyPage Access_Section4_EqualityAndDiversityPolicy()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_3);
            return new EqualityAndDiversityPolicyPage(_context);
        }
        public SafeguardingPolicyPage Access_Section4_SafeguardingPolicy()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_4);
            return new SafeguardingPolicyPage(_context);
        }
        public HealthAndSafetyPolicyPage Access_Section4_HealthAndSafetyPolicy()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_5);
            return new HealthAndSafetyPolicyPage(_context);
        }
        public ActingAsASubContractorPage Access_Section4_ActingAsASubContractor()
        {
            NavigateToTask(ProtectingYourApprentices, ProtectingYourApprentices_6);
            return new ActingAsASubContractorPage(_context);
        }
        #endregion

        #region Section3

        public CriminalAndComplianceChecksPage Access_Section3_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(CriminalAndComplianceChecks, CriminalAndComplianceChecks_1);
            return new CriminalAndComplianceChecksPage(_context);
        }

        public CompositionWithCreditorsPage Access_Section3_ChecksOnYourOrganisation()
        {
            NavigateToTask(CriminalAndComplianceChecks, CriminalAndComplianceChecks_2);
            return new CompositionWithCreditorsPage(_context);
        }
        public WhosInControlCriminalAndComplianceChecksPage Access_Section3_IntroductionWhatYouWillNeedStatusWhosInControl()
        {
            NavigateToTask(CriminalAndComplianceChecks, CriminalAndComplianceChecks_3, 1);
            return new WhosInControlCriminalAndComplianceChecksPage(_context);
        }
        public WhosInControlUnspentCriminalConvictionsPage Access_Section3_ChecksOnWhosInControlOfYourOrganisation()
        {
            NavigateToTask(CriminalAndComplianceChecks, CriminalAndComplianceChecks_4);
            return new WhosInControlUnspentCriminalConvictionsPage(_context);
        }

        #endregion

        #region Section2

        public FinancialHealthAssessmentPage Access_Section2_IntroductionWhatYouwillNeed()
        {
            NavigateToTask(FinancialEvidence, FinancialEvidence_1);
            return new FinancialHealthAssessmentPage(_context);
        }

        public AnnualTurnoverPage Access_Section2_YourOrganisationsFinancialEvidence()
        {
            NavigateToTask(FinancialEvidence, FinancialEvidence_2);
            return new AnnualTurnoverPage(_context);
        }

        public ConsolidatedFinancialStatementsPage Access_Section2_YourUkUltimateParentCompanyFinancialEvidence()
        {
            NavigateToTask(FinancialEvidence, FinancialEvidence_3);
            return new ConsolidatedFinancialStatementsPage(_context);
        }

        #endregion

        #region Seciton1

        public YourOrganisationPage AccessIntroductionWhatYouWillNeedSection()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_1);
            return new YourOrganisationPage(_context);
        }

        public UltimateParentCompanyPage AccessYourOrganisationSectionForOrgTypeCompany()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_2);
            return new UltimateParentCompanyPage(_context);
        }
        public IcoRegistrationNumberPage AccessYourOrganisationSectionForOrgTypeNotACompany()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_2);
            return new IcoRegistrationNumberPage(_context);
        }
        public ConfrimWhosInControlPage AccessTellUSWhosInControlSection()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_3);
            return new ConfrimWhosInControlPage(_context);
        }
        public WhoIsInControlOfYourOrganisationPage AccessTellUsWhosInControlSectionForCHManualEntryTrue()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_3);
            return new WhoIsInControlOfYourOrganisationPage(_context);
        }
        public ConfirmTrusteesPage AccessTellUSWhosInControlSectionForOrgTypeCharity()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_3);
            return new ConfirmTrusteesPage(_context);
        }
        public OrganisationTypePage AccessTellUsWhosInControlSectionForSoleTrader()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_3);
            return new OrganisationTypePage(_context);
        }
        public WhatIsYourOrganisationPage AccessDescribeYourOrganisationsForOrgTypeCharity()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_4);
            return new WhatIsYourOrganisationPage(_context);
        }
        public FundedByTheOfficeForStudentsPage AccessExperienceAndAccreditationsSectionForMainRoute()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_5);
            return new FundedByTheOfficeForStudentsPage(_context);
        }
        public InitialTeacherTrainingPage AccessExperienceAndAccreditationsSectionForEmployerRoute()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_5);
            return new InitialTeacherTrainingPage(_context);
        }
        public ApprenticeshipTrainingAsSubcontractorPage AccessExperienceAndAccreditationsSectionForSupportingRoute()
        {
            NavigateToTask(Yourorganisation, YourOrganisation_5);
            return new ApprenticeshipTrainingAsSubcontractorPage(_context);
        }
        #endregion
    }
}