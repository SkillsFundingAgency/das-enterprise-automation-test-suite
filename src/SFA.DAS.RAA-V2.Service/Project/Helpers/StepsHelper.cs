using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class StepsHelper
    {

        public StepsHelper(ScenarioContext context) { }

        public void VerifyWageType(ProviderVacancySearchResultPage providerVacancySearchResultPage, string wageType)
            => providerVacancySearchResultPage.NavigateToViewAdvertPage().VerifyWageType(wageType);

        public void ApplicantSucessful(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        public void ApplicantUnsucessful(ProviderVacancySearchResultPage providerVacancySearchResultPage)
            => providerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();
        public void ApplicantUnsucessful(EmployerVacancySearchResultPage employerVacancySearchResultPage)
            => employerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();
        public void ApplicantSucessful(EmployerVacancySearchResultPage employerVacancySearchResultPage)
            => employerVacancySearchResultPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();
        public void VerifyWageType(EmployerVacancySearchResultPage employerVacancySearchResultPage, string wageType)
            => employerVacancySearchResultPage.NavigateToViewAdvertPage().VerifyEmployerWageType(wageType);

        public PreviewYourAdvertOrVacancyPage PreviewVacancyForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var locationPage = ChooseEmployerNameForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, employername);
            return FillApprenticeshipDetails(locationPage, isEmployerAddress, disabilityConfidence);
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerNameForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername)
        {
            return employername switch
            {
                RAAV2Const.ExistingTradingName => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseExistingTradingName(),
                RAAV2Const.Anonymous => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseAnonymous(),
                _ => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseRegisteredName(),
            };
            ;
        }

        private PreviewYourAdvertOrVacancyPage FillApprenticeshipDetails(ChooseApprenticeshipLocationPage locationPage, bool isEmployerAddress, bool disabilityConfidence) =>
            locationPage.ChooseAddress(isEmployerAddress).EnterImportantDates(disabilityConfidence)
            .EnterDuration().SelectNationalMinimumWage().PreviewVacancy();
    }
}
