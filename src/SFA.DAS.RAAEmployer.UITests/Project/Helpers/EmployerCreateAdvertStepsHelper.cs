using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAAEmployer.UITests.Project.Helpers
{
    public class EmployerCreateDraftAdvertStepsHelper(ScenarioContext context) : EmployerCreateAdvertStepsHelper(context)
    {
        internal VacancyReferencePage SubmitDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            CheckAndSubmitAdvert(CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants());

        internal CreateAnApprenticeshipAdvertOrVacancyPage CompleteDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants().CheckYourAnswers().PreviewAdvert().DeleteVacancy().NoDeleteVacancy();

        internal EmployerVacancySearchResultPage CompleteDeleteOfDraftVacancy() => new CreateAnApprenticeshipAdvertOrVacancyPage(context).CheckYourAnswers().PreviewAdvert().DeleteVacancy().YesDeleteVacancy();

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert() => CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancy(), false);

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitleMultiOrg(CreateAnApprenticeshipAdvertOrVacancy()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(context); }
    }

    public class EmployerCreateAdvertPrefStepsHelper(ScenarioContext context, RAAEmployerUser rAAEmployerUser) : EmployerCreateAdvertStepsHelper(context)
    {
        protected override YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => rAAEmployerLoginHelper.GoToRecruitmentHomePage(rAAEmployerUser);

        public CreateAnApprenticeshipAdvertOrVacancyPage GoToCreateAnApprenticeshipAdvertPage()
        {
            return rAAEmployerLoginHelper.GoToCreateAnAdvertHomePage(rAAEmployerUser).GoToCreateAnApprenticeshipAdvertPage();
        }

        protected override ApprenticeshipTrainingPage EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            NavigateToAdvertTitle(createAdvertPage).EnterVacancyTitle();
    }

    public class EmployerCreateAdvertStepsHelper(ScenarioContext context) : CreateAdvertVacancyBaseStepsHelper()
    {
        protected readonly ScenarioContext context = context;

        protected readonly RAAEmployerLoginStepsHelper rAAEmployerLoginHelper = new(context);

        internal static CreateAnApprenticeshipAdvertOrVacancyPage CreateFirstDraftAdvert_PrefTest(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return FirstAdvertSummary(createAdvertPage);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateFirstDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return CreateDraftAdvert(createAdvertPage, true);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool createFirstDraftAdvert)
        {

            return EmploymentDetails(createFirstDraftAdvert ? FirstAdvertSummary(createAdvertPage) : AdvertOrVacancySummary(createAdvertPage), true, RAAConst.NationalMinWages);
        }

        internal void CreateFirstAdvertAndSubmit(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            createAdvertPage = CreateFirstDraftAdvert(createAdvertPage);

            createAdvertPage = CompleteAboutTheEmployer(createAdvertPage);

            createAdvertPage = Application(createAdvertPage);

            CheckAndSubmitAdvert(createAdvertPage);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage AddAnAdvert()
        {
            new RecruitmentDynamicHomePage(context, true).ContinueToCreateAdvert();

            return new DoYouNeedToCreateAnAdvertPage(context).ClickYesRadioButtonTakesToRecruitment().GoToCreateAnApprenticeshipAdvertPage();
        }

        internal void CreateOfflineVacancy()
        {
            CreateANewAdvert(true);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal VacancyReferencePage CloneAnAdvert() => SubmitAndSetVacancyReference(GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert()
            .SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage().UpdateAdditionalQuestion().UpdateAllAdditionalQuestionsAndGoToCheckYourAnswersPage());

        internal VacancyReferencePage CreateANewAdvert_WageType(string wageType) => CreateANewAdvert(string.Empty, true, false, wageType);

        internal VacancyReferencePage CreateANewAdvert() => CreateANewAdvert(RAAConst.LegalEntityName);

        internal VacancyReferencePage CreateANewAdvert(string employername) => CreateANewAdvert(employername, true);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress) => CreateANewAdvert(employername, isEmployerAddress, false, RAAConst.NationalMinWages);

        internal VacancyReferencePage CreateANewAdvert(bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(string.Empty, true, true, RAAConst.NationalMinWages, isApplicationMethodFAA, false);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType) => CreateANewAdvertOrVacancy(employername, isEmployerAddress, disabilityConfidence, wageType, true, false);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy() => GoToRecruitmentHomePage().CreateAnApprenticeshipAdvert().GoToCreateAnApprenticeshipAdvertPage();

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
                    AdvertSummary(EnterAdvertTitle(createAdvertPage));

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReference() => rAAEmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA) =>
            createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(disabilityConfidence, optionalFields)
                .EnterContactDetailsAndGoToApplicationProcessPage(optionalFields)
                .SelectApplicationMethod_Employer(isApplicationMethodFAA);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage
                .Skills()
                .SelectSkillAndGoToQualificationsPage()
                .SelectYesToAddQualification()
                .EnterQualifications()
                .ConfirmQualificationsAndGoToFutureProspectsPage()
                .EnterFutureProspect()
                .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, string wageType) =>
            createAdvertPage
                .ImportantDates()
                .EnterImportantDates()
                .EnterDuration()
                .ChooseWage_Employer(wageType)
                .SubmitExtraInformationAboutPay()
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress ? "employer" : "multiple");


        protected override CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage
            .EnterAdditionalQuestionsForApplicants()
            .CompleteAllAdditionalQuestionsForApplicants();

        protected CreateAnApprenticeshipAdvertOrVacancyPage CompleteAboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            AboutTheEmployer(SkillsAndQualifications(createAdvertPage), string.Empty, true, true);

        private static CreateAnApprenticeshipAdvertOrVacancyPage FirstAdvertSummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            AdvertSummary(NavigateToAdvertTitle(createAdvertPage).EnterVacancyTitleForTheFirstAdvert().SelectYes());

        protected virtual ApprenticeshipTrainingPage EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            EnterAdvertTitleMultiOrg(createAdvertPage).SelectOrganisationMultiOrg();

        protected static SelectOrganisationPage EnterAdvertTitleMultiOrg(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            NavigateToAdvertTitle(createAdvertPage).EnterAdvertTitleMultiOrg();

        private static CreateAnApprenticeshipAdvertOrVacancyPage AdvertSummary(ApprenticeshipTrainingPage page) =>
        page.EnterTrainingTitle()
            .ConfirmTrainingproviderAndContinue()
            .SelectTrainingProvider()
            .ConfirmProviderAndContinueToSummaryPage()
            .EnterShortDescription()
            .EnterShortDescriptionOfWhatApprenticeWillDo()
            .EnterAllDescription();

        protected virtual YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => rAAEmployerLoginHelper.GoToRecruitmentHomePage();
    }
}