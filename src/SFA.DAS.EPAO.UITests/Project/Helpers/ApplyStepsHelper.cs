using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class ApplyStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ApplyStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public AP_ApplicationOverviewPage CompletePreambleJourney(string orgName)
        {
            _objectContext.SetApplyOrganisationName(orgName);

            return new AP_PR1_SearchForYourOrganisationPage(_context)
                .EnterOrgNameAndSearchInSearchForYourOrgPage()
                .ClickOrgLinkFromSearchResultsForPage()
                .SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
                .ClickConfirmAndApplyButtonInConfirmOrgPage()
                .ClickAcceptAndContinueInDeclarationPage();
        }

        public AP_ApplicationOverviewPage CompleteOrganisationDetailsSection(AP_ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .ClickGoToOrganisationDetailsLinkInApplicationOverviewPage()
                .ClickTradingNameLinkInOrganisationDetailsBasePage()
                .GiveATradingNameAndContinueInTradingNamePage()
                .SelectYesAndContinueInUseYourTradingNameOnTheRegisterPage()
                .EnterContactDetailsAndContinueInContactDetailsPage()
                .EnterContactDetailsAndContinueInContractNoticeToPage()
                .EnterUkprnAndContinueInDoYouHaveAUkprnPage()
                .EnterDetailsAndContinueInOEMPage()
                .EnterDetailsAndContinueInOfqualRecognitionNumberPage()
                .SelectPubliLimitedCompanyOptionAndContinueInTradingStatusPage()
                .EnterNumberAndContinueInCompanyNumberPage()
                .EnterNumberAndContinueInDirectoDetailsPage()
                .SelectNoOptionAndContinueInDirectorsDataPage()
                .EnterCharityDetailsAndContinueInRegisteredCharityPage()
                .SelectNoOptionAndContinueInRegisterOfRemovedTrusteesPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyOrganisationDetailsSectionCompletedText();
        }

        public AP_ApplicationOverviewPage CompleteDeclarationsSection(AP_ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .ClickGoToDeclarationsLinkInApplicationOverviewPage()
                .ClickNameAndJobTitleLinkInDeclarationsBasePage()
                .EnterDetailsAndContinueInAuthoriserDetailsPagePage()
                .SelectNoOptionAndContinueInCriminalConvictionsPage()
                .SelectNoOptionAndContinueInFinancialConvictionsPage()
                .SelectNoOptionAndContinueInCounterTerrorismPage()
                .SelectNoOptionAndContinueInOtherCriminalConvictionsPage()
                .SelectNoOptionInTaxAndSocialSecurityIrregularitiesPage()
                .SelectNoOptionAndContinueInBankruptcyAndInsolvencyPage()
                .SelectNoOptionAndContinueInCessationOfTradingPage()
                .SelectNoOptionAndContinueInTheIncorrectTaxReturnsPage()
                .SelectNoOptionAndContinueInHmrcChallengesPage()
                .SelectNoOptionAndContinueInContractsWithdrawnFromYouPage()
                .SelectNoOptionAndContinueInContractsYouHaveWithdrawnFromPage()
                .SelectNoOptionAndContinueInOrganisationRemovalFromRegistersPage()
                .SelectNoOptionAndContinueInDirectionAndSanctionsPage()
                .SelectNoOptionAndContinueInRepaymentOfPublicMoneyPage()
                .SelectNoOptionAndContinueInPublicbodyFundsAndContractsPage()
                .SelectNoOptionAndContinueInLegalDisputePage()
                .SelectYesOptionAndContinueInFalseDeclarationsPage()
                .SelectYesOptionAndContinueInAccurateRepresentationPage()
                .SelectYesOptionAndContinueInAgreementOnTheRegisterPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyDeclarationsSectionCompletedText();
        }

        public AP_ApplicationOverviewPage CompletesTheFHASection(AP_ApplicationOverviewPage applicationOverviewPage)
        {
            return applicationOverviewPage
                .ClickGoToFinancialHealthAssessmentLinkInApplicationOverviewPage()
                .ClickFHALinkInFHABasePage()
                .UploadFileAndContinueInFinancialHealthPage()
                .ClickReturnToApplicationOverviewButton()
                .VerifyFHASectionCompletedText();
        }

        public void SubmitApplication(AP_ApplicationOverviewPage applicationOverviewPage) => applicationOverviewPage.ClickSubmitInApplicationOverviewPage();

        public AS_ApplicationSubmittedPage ApplyForAStandard(AS_ApplyForAStandardPage aS_ApplyForAStandardPage)
        {
            var applyToStandard = aS_ApplyForAStandardPage
                .Start()
                .EnterStandardName()
                .Apply()
                .ConfirmAndApply()
                .GoToApplyToStandard();

            applyToStandard = applyToStandard.AccessYourPolicies_01()
                .EnterRegNumber()
                .UploadAuditPolicy()
                .UploadPublicLiabilityInsurance()
                .UploadProfessionalIndemnityInsurance()
                .UploadEmployersLiabilityInsurance()
                .UploadSafeguardingPolicy()
                .UploadPreventAgendaPolicy()
                .UploadConflictOfinterestPolicy()
                .UploadMonitoringProcedure()
                .UploadModerationProcesses()
                .UploadComplaintsPolicy()
                .UploadFairAccess()
                .UploadConsistencyAssurance()
                .EnterImproveTheQuality()
                .EnterEngagement()
                .EnterMembershipDetails()
                .EnterHowManyAssessors()
                .EnterHowManyEndPointAssessment()
                .EnterVolume()
                .EnterHowRecruitAndTrainAssessors()
                .EnterExperience()
                .EnterOccupationalExpertise()
                .EnterDeliverEndPoint()
                .EnterIntendToOutsource()
                .EnterEngageWithEmployers()
                .EnterManageAnyPotentialConflict()
                .ChooseLocation()
                .EnterDayToStart()
                .EnterAssessmentPlan()
                .EnterReviewAndMaintainPlan()
                .EnterSecureITInfrastructurePlan()
                .EnterAssessmentAdministration()
                .EnterAssessmentProduct()
                .EnterAssessmentContent()
                .EnterCollationOutcome()
                .EnterAssessmentResutls()
                .EnterWebAddress();

            return applyToStandard.ReturnToApplicationOverview().Submit();
        }

    }
}
