using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class StepsHelper
    {

        public StepsHelper(ScenarioContext context) { }

        public void VerifyWageType(ManageRecruitPage manageVacancyPage, string wageType)
            => manageVacancyPage.NavigateToViewAdvertPage().VerifyWageType(wageType);

        public void ApplicantSucessful(ManageRecruitPage manageVacancyPage)
            => manageVacancyPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        public void ApplicantUnsucessful(ManageRecruitPage manageVacancyPage)
            => manageVacancyPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();

        public PreviewYouAdvertOrVacancyPage PreviewVacancyForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername, bool isEmployerAddress, bool disabilityConfidence)
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

        private PreviewYouAdvertOrVacancyPage FillApprenticeshipDetails(ChooseApprenticeshipLocationPage locationPage, bool isEmployerAddress, bool disabilityConfidence) =>
            locationPage.ChooseAddress(isEmployerAddress).EnterImportantDates(disabilityConfidence)
            .EnterDuration().SelectNationalMinimumWage().PreviewVacancy();
    }
}
