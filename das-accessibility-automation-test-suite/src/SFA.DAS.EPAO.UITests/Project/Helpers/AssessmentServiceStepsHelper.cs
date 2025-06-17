namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class AssessmentServiceStepsHelper(ScenarioContext context)
{
    private readonly EPAOAdminDataHelper _ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();

    public void VerifyApprenticeGrade(string grade, LearnerCriteria learnerCriteria)
    {
        bool gradeValidation;

        var recordAGradePage = GoToRecordAGradePage();

        if (learnerCriteria.HasMultiStandards)
            gradeValidation = recordAGradePage.SearchApprentice(false).ViewCertificateHistory().VerifyGrade(grade);
        else
        {
            if (grade.ContainsCompareCaseInsensitive("pass")) gradeValidation = recordAGradePage.GoToAssesmentAlreadyRecordedPage().VerifyGrade(grade);

            else gradeValidation = recordAGradePage.SearchApprentice(false).VerifyGrade(grade);
        }

        Assert.AreEqual(true, gradeValidation, $"Apprentice grade is not recorded as {grade}");
    }

    public AS_CheckAndSubmitAssessmentPage CertifyApprentice(string grade, string route, LearnerCriteria learnerCriteria, bool deleteCertificate)
    {
        var confirmApprenticePage = GoToRecordAGradePage().SearchApprentice(deleteCertificate);

        AS_DeclarationPage decPage = CertifyApprentice(confirmApprenticePage, learnerCriteria);

        return SelectGrade(decPage, grade, route);
    }

    public static void RemoveChangeOrgDetailsPermissionForTheUser(AS_LoggedInHomePage loggedInHomePage)
    {
        loggedInHomePage.ClickManageUsersLink()
            .ClickManageUserNameLink()
            .ClickEditUserPermissionLink()
            .UnSelectChangeOrganisationDetailsCheckBox()
            .ClickSaveButton();
    }

    public static AS_OrganisationDetailsPage ChangeContactName(AS_OrganisationDetailsPage organisationDetailsPage)
    {
        return organisationDetailsPage.ClickContactNameChangeLink()
            .SelectContactNameRadioButtonAndClickSave()
            .ClickConfirmButtonInConfirmContactNamePage()
            .ClickViewOrganisationDetailsLink();
    }

    public static AS_OrganisationDetailsPage ChangePhoneNumber(AS_OrganisationDetailsPage organisationDetailsPage)
    {
        return organisationDetailsPage.ClickPhoneNumberChangeLink()
           .EnterRandomPhoneNumberAndClickUpdate()
           .ClickConfirmButtonInConfirmPhoneNumberPage()
           .ClickViewOrganisationDetailsLink();
    }

    public static AS_OrganisationDetailsPage ChangeAddress(AS_OrganisationDetailsPage organisationDetailsPage)
    {
        return organisationDetailsPage.ClickAddressChangeLink()
            .ClickSearchForANewAddressLink()
            .ClickEnterTheAddressManuallyLink()
            .EnterEmployerAddressAndClickChangeAddressButton()
            .ClickConfirmAddressButtonInConfirmContactAddressPage()
            .ClickViewOrganisationDetailsLink();
    }

    public static AS_OrganisationDetailsPage ChangeEmailAddress(AS_OrganisationDetailsPage organisationDetailsPage)
    {
        return organisationDetailsPage.ClickEmailChangeLink()
            .EnterRandomEmailAndClickChange()
            .ClickConfirmButtonInConfirmEmailAddressPage()
            .ClickViewOrganisationDetailsLink();
    }

    public static AS_OrganisationDetailsPage ChangeWebsiteAddress(AS_OrganisationDetailsPage organisationDetailsPage)
    {
        return organisationDetailsPage.ClickWebsiteChangeLink()
            .EnterRandomWebsiteAddressAndClickUpdate()
            .ClickConfirmButtonInConfirmWebsiteAddressPage()
            .ClickViewOrganisationDetailsLink();
    }

    public static string InviteAUser(AS_LoggedInHomePage _loggedInHomePage) => _loggedInHomePage.ClickManageUsersLink().ClickInviteNewUserButton().EnterUserDetailsAndSendInvite();

    public void DeleteCertificate(StaffDashboardPage staffDashboardPage)
    {
        staffDashboardPage
            .Search()
            .SearchFor(_ePAOAdminDataHelper.LearnerUln)
            .SelectACertificate()
            .ClickDeleteCertificateLink()
            .ClickYesAndContinue()
            .EnterAuditDetails()
            .ClickDeleteCertificateButton()
            .ClickReturnToDashboard();
    }

    private AS_RecordAGradePage GoToRecordAGradePage() => new AS_LoggedInHomePage(context).GoToRecordAGradePage();

    private AS_CheckAndSubmitAssessmentPage SelectGrade(AS_DeclarationPage decpage, string grade, string route)
    {
        decpage.ClickConfirmInDeclarationPage();

        new AS_WhatGradePage(context).SelectGradeAndEnterDate(grade);

        if (route == "employer") return SelectGradeEmployerRoute(grade);

        else return SelectGradeApprenticeRoute(grade);
    }

    private AS_CheckAndSubmitAssessmentPage SelectGradeApprenticeRoute(string grade)
    {
        if (grade == "pass")
        {
            return new AS_WhoWouldYouLikeUsToSendTheCertificateToPage(context)
            .ClickAprenticeRadioButton()
            .ClickEnterAddressManuallyLinkInSearchEmployerPage()
            .EnterEmployerAddressAndContinue()
            .ClickContinueInConfirmEmployerAddressPage();
        }
        else if (grade == "PassWithExcellence") PassWithExcellence();

        return new AS_CheckAndSubmitAssessmentPage(context);
    }

    private AS_CheckAndSubmitAssessmentPage SelectGradeEmployerRoute(string grade)
    {
        if (grade == "pass")
        {
            return new AS_WhoWouldYouLikeUsToSendTheCertificateToPage(context)
            .ClickEmployerRadioButton()
            .ClickEnterAddressManuallyLinkInSearchEmployerPage()
            .EnterEmployerNameAndAddressAndContinue()
            .AddRecipientAndContinue()
            .ClickContinueInConfirmEmployerAddressPage();
        }
        else if (grade == "PassWithExcellence") PassWithExcellence();

        return new AS_CheckAndSubmitAssessmentPage(context);
    }

    private AS_CheckAndSubmitAssessmentPage PassWithExcellence() => new AS_ConfirmAddressPage(context).ClickContinueInConfirmEmployerAddressPage();

    private static AS_DeclarationPage CertifyApprentice(AS_ConfirmApprenticePage confirmApprenticePage, LearnerCriteria learnerCriteria)
    {
        if (learnerCriteria.HasMultipleVersions)
        {
            if (learnerCriteria.VersionConfirmed)
                return confirmApprenticePage.ConfirmAndContinue();

            else
            {
                var whichVersionPage = confirmApprenticePage.GoToWhichVersionPage(learnerCriteria.HasMultiStandards);

                if (learnerCriteria.WithOptions) return whichVersionPage.ClickConfirmInConfirmVersionPage().SelectLearningOptionAndContinue();

                else return whichVersionPage.ClickConfirmInConfirmVersionPageNoOption();
            }
        }
        else
        {
            if (learnerCriteria.WithOptions) return confirmApprenticePage.GoToWhichLearningOptionPage(learnerCriteria.HasMultiStandards).SelectLearningOptionAndContinue();

            else return confirmApprenticePage.GoToDeclarationPage(learnerCriteria.HasMultiStandards);
        }
    }
}