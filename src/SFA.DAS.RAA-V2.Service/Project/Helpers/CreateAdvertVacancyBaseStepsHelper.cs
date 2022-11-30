using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public abstract class CreateAdvertVacancyBaseStepsHelper
    {
        protected static string NotStarted => "NOT STARTED";

        protected static string Completed => "COMPLETED";

        protected static string InProgress => "IN PROGRESS";

        public bool optionalFields;

        public CreateAdvertVacancyBaseStepsHelper() => optionalFields = false;

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy();
        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage CreateNewTraineeshipVacancy();
        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage page);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, string wageType);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployerTraineeship(CreateAnApprenticeshipAdvertOrVacancyPage createTraineeshipPage, string employername);

        protected WhatDoYouWantToCallThisAdvertPage NavigateToAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => createAdvertPage.AdvertTitle();

        protected VacancyReferencePage CheckAndSubmitAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            SubmitAndSetVacancyReference(createAdvertPage.CheckYourAnswers());

        protected VacancyReferencePage SubmitAndSetVacancyReference(CheckYourAnswersPage checkYourAnswersPage) =>
            checkYourAnswersPage.SubmitAdvert().SetVacancyReference();


        protected VacancyReferencePage CreateANewAdvertOrVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType, bool isApplicationMethodFAA)
        {
            var createAdvertPage = CreateAnApprenticeshipAdvertOrVacancy();

            //createAdvertPage.VerifyAdvertSummarySectionStatus(InProgress);

            createAdvertPage = AdvertOrVacancySummary(createAdvertPage);

            createAdvertPage.VerifyAdvertSummarySectionStatus(Completed);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(NotStarted);

            createAdvertPage = EmploymentDetails(createAdvertPage, isEmployerAddress, wageType);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(Completed);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(NotStarted);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(Completed);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(NotStarted);

            createAdvertPage = AboutTheEmployer(createAdvertPage, employername, disabilityConfidence, isApplicationMethodFAA);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(Completed);

            createAdvertPage.VerifyCheckandsubmityouradvertSectionStatus(InProgress);

            return CheckAndSubmitAdvert(createAdvertPage);
        }

        protected VacancyReferencePage CreateANewTraineeshipVacancy(string employerName, bool isEmployerAddress,
            bool disabilityConfidence)
        {
            var createTraineeshipPage = CreateNewTraineeshipVacancy();

            createTraineeshipPage.VerifyAdvertSummarySectionStatus(InProgress);

            createTraineeshipPage = AdvertOrVacancySummary(createTraineeshipPage);

            createTraineeshipPage.VerifyAdvertSummarySectionStatus(Completed);

            createTraineeshipPage.VerifyEmploymentDetailsSectionStatus(NotStarted);

            createTraineeshipPage = EmploymentDetails(createTraineeshipPage, isEmployerAddress, "");

            createTraineeshipPage.VerifyEmploymentDetailsSectionStatus(Completed);

            createTraineeshipPage.VerifySkillsandqualificationsSectionStatus(NotStarted);

            createTraineeshipPage = SkillsAndQualifications(createTraineeshipPage);

            createTraineeshipPage.VerifySkillsandqualificationsSectionStatus(Completed);

            createTraineeshipPage.VerifyAbouttheemployerSectionStatus(NotStarted);

            createTraineeshipPage = AboutTheEmployerTraineeship(createTraineeshipPage, employerName);

            createTraineeshipPage.VerifyAbouttheemployerSectionStatus(Completed);

            return CheckAndSubmitAdvert(createTraineeshipPage);
        }
    }
}