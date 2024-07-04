using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Helpers
{
    public class StepsHelper(ScenarioContext context)
    {
        public ScenarioContext Context { get; } = context;

        public static void VerifyWageType(ProviderVacancySearchResultPage providerVacancySearchResultPage, string wageType)
            => providerVacancySearchResultPage.NavigateToViewAdvertPage().VerifyWageType(wageType);
        public static void InterviewApplicant(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageApplicant().MarkApplicantInterviewWithEmployer();     
        public static void ApplicantSucessful(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageApplicant().ProviderMakeApplicantSucessful().ConfirmSuccessful();
        public static void MultiShareApplicants(ProviderVacancySearchResultPage providerVacancySearchResultPage)
           => providerVacancySearchResultPage.NavigateToManageApplicants().ProviderShareApplicantWithEmployer().ConfirmSharing();
        public static void ApplicantShared(ProviderVacancySearchResultPage providerVacancySearchResultPage)
           => providerVacancySearchResultPage.NavigateToManageApplicant().ProviderShareApplicantWithEmployer().ConfirmSharing();

        public static void ApplicantUnsucessful(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageApplicant().ProviderMakeApplicantUnsucessful().FeedbackForUnsuccessful().ConfirmUnsuccessful();
        public static void MultiApplicantsUnsucessful(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageAllApplicants().ProviderMakeAllSelectedApplicantsUnsucessful().FeedbackForMultipleUnsuccessful().ConfirmUnsuccessful();
        public static void ApplicantUnsucessful(EmployerVacancySearchResultPage employerVacancySearchResultPage)
            => employerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();
        public static void ApplicantSucessful(EmployerVacancySearchResultPage employerVacancySearchResultPage)
            => employerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();
        public static void VerifyWageType(EmployerVacancySearchResultPage employerVacancySearchResultPage, string wageType)
            => employerVacancySearchResultPage.NavigateToViewAdvertPage().VerifyEmployerWageType(wageType);

        public static ChooseApprenticeshipLocationPage ChooseEmployerNameForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername)
        {
            return employername switch
            {
                RAAV2Const.ExistingTradingName => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseExistingTradingName(),
                RAAV2Const.Anonymous => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseAnonymous(),
                _ => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseRegisteredName(),
            };
            ;
        }
    }
}
