using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {
        private readonly ScenarioContext _context;

        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public AS_LoggedInHomePage LoginToAssessmentServiceApplication() => new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails();

        public void CertifyApprentice(string grade, string enrolledStandard)
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchApprentice(enrolledStandard)
                .ClickConfirmInConfirmApprenticePage(enrolledStandard)
                .ClickConfirmInDeclarationPage();

            if (enrolledStandard == "additional learning option")
                new AS_WhichLearningOptionPage(_context).SelectLearningOptionAndContinue();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "Passed")
                new AS_SearchEmployerAddress(_context).SearchAndSelectEmployerAddress()
               .ClickContinueInSearchEmployerAddressPage()
               .ClickContinueInConfirmEmployerAddressPage()
               .EnterRecipientDetailsAndContinue()
               .ClickContinueInCheckAndSubmitAssessmentPage();
            else if (grade == "Failed")
                new AS_CheckAndSubmitAssessmentPage(_context).ClickContinueInCheckAndSubmitAssessmentPage();
        }
    }
}
