namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class ApplyStepsHelper(ScenarioContext context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    public AP_ApplicationOverviewPage CompletePreambleJourney(AP_PR1_SearchForYourOrganisationPage searchForYourOrganisationPage, string orgName)
    {
        _objectContext.SetApplyOrganisationName(orgName);

        return searchForYourOrganisationPage
            .EnterOrgNameAndSearchInSearchForYourOrgPage()
            .ClickOrgLinkFromSearchResultsForPage()
            .SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
            .ClickConfirmAndApplyButtonInConfirmOrgPage()
            .ClickAcceptAndContinueInDeclarationPage();
    }

    public static AP_ApplicationOverviewPage CompleteOrganisationDetailsSection(AP_ApplicationOverviewPage applicationOverviewPage)
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

    public static AP_ApplicationOverviewPage CompleteDeclarationsSection(AP_ApplicationOverviewPage applicationOverviewPage)
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

    public static bool GoToFinancialHealthAssessmentLinkExists(AP_ApplicationOverviewPage applicationOverviewPage) => applicationOverviewPage.GoToFinancialHealthAssessmentLinkExists();

    public static AP_ApplicationOverviewPage CompletesTheFHASection(AP_ApplicationOverviewPage applicationOverviewPage)
    {
        return applicationOverviewPage
            .ClickGoToFinancialHealthAssessmentLinkInApplicationOverviewPage()
            .ClickFHALinkInFHABasePage()
            .UploadFileAndContinueInFinancialHealthPage()
            .ClickReturnToApplicationOverviewButton()
            .VerifyFHASectionCompletedText();
    }

    public static void SubmitApplication(AP_ApplicationOverviewPage applicationOverviewPage) => applicationOverviewPage.ClickSubmitInApplicationOverviewPage();

    public AS_ApplicationSubmittedPage ApplyForAStandard(AS_ApplyForAStandardPage aS_ApplyForAStandardPage, string standardName)
    {
        _objectContext.SetApplyStandardName(standardName);

        var applyToStandard = aS_ApplyForAStandardPage
            .Start()
            .EnterStandardName()
            .Apply()
            .ConfirmAndApplyWithVersion()
            .GoToApplyToStandard();

        applyToStandard = ApplyToStandard(applyToStandard);

        return applyToStandard.ReturnToApplicationOverview().Submit();
    }

    public void ApplyStageTwoStandard()
    {
        AS_ApplyForAStandardPage _aS_ApplyForAStandardPage = new(context);

        var applyToStandard = _aS_ApplyForAStandardPage.Start()
        .EnterStandardToCancelName()
        .Apply()
        .ConfirmAndApply()
        .GoToApplyToStandard();

        applyToStandard = ApplyToStandard(applyToStandard);

        applyToStandard.ReturnToApplicationOverview();
    }

    private static AS_ApplyToStandardPage ApplyToStandard(AS_ApplyToStandardPage applyToStandard)
    {
        applyToStandard = applyToStandard.AccessYourPolicies_01()
            .NHEIEnterRegNumber()
            .NHEIUploadPublicLiabilityInsurance()
            .NHEIUploadProfessionalIndemnityInsurance()
            .NHEIUploadEmployersLiabilityInsurance()
            .NHEIEnterHowManyAssessors()
            .NHEIEnterHowManyEndPointAssessment()
            .NHEIEnterVolume()
            .NHEIChooseLocation()
            .NHEIEnterDayToStart();
            return applyToStandard;
    }
}