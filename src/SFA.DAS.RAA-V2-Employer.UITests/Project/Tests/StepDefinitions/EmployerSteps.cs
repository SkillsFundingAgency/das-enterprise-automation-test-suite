using NUnit.Framework;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly RAAV2DataHelper _rAAV2DataHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;

        private VacancyPreviewPart2Page _vacancyPreviewPart2Page;
        private VacancyPreviewPart2WithErrorsPage _vacancyPreviewPart2WithErrorsPage;
        private RecruitmentDynamicHomePage _dynamicHomePage;
        private DeleteVacancyQuestionPage _deleteVacancyQuestionPage;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _rAAV2DataHelper = context.Get<RAAV2DataHelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
        }

        [Given(@"the Employer completes the first part of the journey")]
        public void GivenTheEmployerCompletesTheFirstPartOfTheJourney() => _vacancyPreviewPart2Page = _employerStepsHelper.PreviewVacancy(string.Empty, true, false);

        [When(@"the Employer submits the vacancy")]
        public void WhenTheEmployerSubmitsTheVacancy() => _vacancyPreviewPart2WithErrorsPage = _vacancyPreviewPart2Page.SubmitVacancyWithMissingData();

        [When(@"the Employer saves the vacancy as a draft")]
        public void WhenTheEmployerSavesTheVacancyAsADraft() => _vacancyPreviewPart2Page.ReturnToDashboard();

        [Then(@"the Employer can cancel deleting the draft vacancy")]
        public void ThenTheEmployerCanCancelDeletingTheDraftVacancy() => _employerStepsHelper.NoDeleteDraftVacancy(_deleteVacancyQuestionPage);

        [Then(@"Employer can make the application successful")]
        public void ThenEmployerCanMakeTheApplicationSuccessful() => _employerStepsHelper.ApplicantSucessful();

        [Then(@"Employer can make the application unsuccessful")]
        public void ThenEmployerCanMakeTheApplicationUnsuccessful() => _employerStepsHelper.ApplicantUnsucessful();

        [Then(@"the Employer can close the vacancy")]
        public void ThenTheEmployerCanCloseTheVacancy() => _employerStepsHelper.CloseVacancy();

        [Then(@"the Employer can edit the vacancy")]
        public void ThenTheEmployerCanEditTheVacancy() => _employerStepsHelper.EditVacancyDates();

        [Then(@"the Employer is able to delete the draft vacancy")]
        public void ThenTheEmployerIsAbleToDeleteTheDraftVacancy() => _employerStepsHelper.CompleteDeleteOfDraftVacancy();

        [Then(@"submission errors displayed for not completing the mandatory information")]
        public void ThenSubmissionErrorsDisplayedForNotCompletingTheMandatoryInformation()
        {
            List<string> expectedMessges = new List<string>
            {
                "Enter a short description of the apprenticeship",
                "Enter what the apprentice will be doing",
                "Enter the training the apprentice will take and the qualification the apprentice will get",
                "Enter the expected career progression after this apprenticeship",
                "Select the skills and personal qualities you'd like the applicant to have",
                "You must add a qualification",
                "Select how you'd like to receive applications",
            };

            var actualMessages = _vacancyPreviewPart2WithErrorsPage.GetErrorMessages();

            Assert.IsTrue(expectedMessges.All(x => actualMessages.Contains(x)), $"Not all messages are found. {_employerStepsHelper.DeleteDraftVacancy(_vacancyPreviewPart2Page)}");
        }

        [Then(@"the Employer verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type)' the wage option selected in the Preview page")]
        public void ThenTheEmployerVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _employerStepsHelper.VerifyWageType(wageType);

        [Then(@"the vacancy details is displayed on the Dynamic home page with Status '(DRAFT|CLOSED|PENDING REVIEW|LIVE|REJECTED)'")]
        public void GivenTheVacancyDetailsIsDisplayedOnTheDynamicHomePageWithStatus(string status)
        {
            switch (status)
            {
                case "DRAFT":
                case "REJECTED":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(_context, true).ConfirmVacancyTitleAndStatus(status);
                    break;

                case "CLOSED":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(_context, true).ConfirmClosedVacancyDetails(status);
                    break;

                case "PENDING REVIEW":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(_context, true).ConfirmVacancyDetails(status, _rAAV2DataHelper.VacancyClosing);
                    break;

                case "LIVE":
                    _dynamicHomePage = new RecruitmentDynamicHomePage(_context, true).ConfirmLiveVacancyDetails(status);
                    break;
            }
        }

        [Then(@"Employer can go to vacancy dashboard")]
        public void ThenEmployerCanGoToVacancyDashboard() => _dynamicHomePage.GoToVacancyDashboard();

        [Then(@"Employer can go to Manage vacancy page")]
        public void ThenEmployerCanGoToManageVacancyPage() => _dynamicHomePage.GoToManageVacancyPage();

        [Then(@"Employer can continue creating an advert")]
        public void ThenEmployerCanContinueCreatingAnAdvert() => _dynamicHomePage.ContinueCreatingYourAdvert();

        [Given(@"the Employer logs into Employer account")]
        public void GivenTheEmployerLogsIntoEmployerAccount() => _homePageStepsHelper.GotoEmployerHomePage();

        [Then(@"the Employer can review and resubmit the vacancy")]
        public void ThenTheEmployerCanReviewAndResubmitTheVacancy() => _dynamicHomePage.ReviewYourVacancy().ResubmitVacancy();
    }
}
