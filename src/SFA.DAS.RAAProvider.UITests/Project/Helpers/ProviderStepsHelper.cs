using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderStepsHelper(ScenarioContext context) : ProviderBaseStepsHelper(context)
    {
        public ProviderVacancySearchResultPage SearchVacancy() => GoToRecruitmentHomePage().SearchVacancy();

        internal void ViewReferVacancy() => GoToRecruitmentHomePage().SearchReferAdvertTitle();
        internal void ApplicantReview() => StepsHelper.ApplicantInReview(SearchVacancyByVacancyReference());
        internal void ApplicantSucessful() => StepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());
        internal void ApplicantWithdrawn() => StepsHelper.ApplicantWithdrawn(SearchVacancyByVacancyReference());
        internal void ShareMutipleApplicants() => StepsHelper.MultiShareApplicants(SearchVacancyByVacancyReference());

        internal void ApplicantShared() => StepsHelper.ApplicantShared(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => StepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());
        internal void MutipleApplicantsUnsucessful() => StepsHelper.MultiApplicantsUnsucessful(SearchVacancyByVacancyReference());

        internal void InterviewWithEmployer() => StepsHelper.InterviewApplicant(SearchVacancyByVacancyReference());
        internal void VerifyWageType(string wageType) => StepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => GoToRecruitmentHomePage().SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage() => GoToRecruitmentHomePage(true);
       
        internal void CloseVacancy() => SearchVacancyByVacancyReference().GoToVacancyManagePage().CloseAdvert().YesCloseThisVacancy();

        internal void EditVacancyDates() => SearchVacancyByVacancyReference().GoToVacancyManagePage().EditAdvert().EnterProviderVacancyDates();

    }
}