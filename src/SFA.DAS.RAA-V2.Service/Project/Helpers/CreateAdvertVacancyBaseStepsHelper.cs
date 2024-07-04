using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public abstract class CreateAdvertVacancyBaseStepsHelper
    {
        protected static string NotStarted => "Not started";

        protected static string Completed => "Completed";

        protected static string InProgress => "In progress";

        public bool optionalFields;

        public CreateAdvertVacancyBaseStepsHelper() => optionalFields = false;

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy();
        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage page);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, string wageType);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage);

        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA);
        protected abstract CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage);

        protected static WhatDoYouWantToCallThisAdvertPage NavigateToAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => createAdvertPage.AdvertTitle();

        protected static VacancyReferencePage CheckAndSubmitAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            SubmitAndSetVacancyReference(createAdvertPage.CheckYourAnswers());

        protected static VacancyReferencePage SubmitAndSetVacancyReference(CheckYourAnswersPage checkYourAnswersPage) =>
            checkYourAnswersPage.SubmitAdvert().SetVacancyReference();


        protected VacancyReferencePage CreateANewAdvertOrVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType, bool isApplicationMethodFAA, bool isProvider)
        {
            var createAdvertPage = CreateAnApprenticeshipAdvertOrVacancy();

            createAdvertPage.VerifyAdvertSummarySectionStatus(isProvider ? InProgress : NotStarted);

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

            createAdvertPage.VerifyApplicationSectionStatus(NotStarted);

            createAdvertPage = Application(createAdvertPage);

            createAdvertPage.VerifyApplicationSectionStatus(Completed);

            createAdvertPage.VerifyCheckandsubmityouradvertSectionStatus(InProgress);

            return CheckAndSubmitAdvert(createAdvertPage);
        }
    }
}