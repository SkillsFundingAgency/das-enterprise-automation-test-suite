using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class PreviewYourAdvertOrVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Preview your advert" : "Preview your vacancy";

        protected override bool TakeFullScreenShot => false;

        private static By BriefOverview => By.CssSelector("a[data-automation='link-overview']");
        private static By VacancyDescription => By.CssSelector("a[data-automation='link-vacancy-description']");
        private static By DesiredSkills => By.CssSelector("a[data-automation='link-skills']");
        private static By Qualifications => By.CssSelector("a[data-automation= 'link-qualifications']");
        private static By EmployerDescription => By.CssSelector("a[data-automation='link-description']");
        private static By ApplicationProcess => By.CssSelector("a[data-automation='link-application-method']");
        private static By ThingsToConsider => By.CssSelector("a[data-automation='link-things-to-consider']");
        private static By EmployerContactDetails => By.CssSelector("a[data-automation='link-employer-contact-details']");
        private static By ProviderContactDetails => By.CssSelector("a[data-automation='link-provider-contact-details']");
        private static By Submit => By.CssSelector(".govuk-button[data-automation='submit-button']");
        private static By ReturnToDashboardLink => By.CssSelector("a[data-automation='dashboard-link']");
        private static By DeleteVacancyButton => By.CssSelector("a[data-automation='delete-button']");
        private static By ChangeApplicationProcess => By.CssSelector("a[data-automation='link-application-link']");
        private static By ApplicationWebAddress => By.Id("ApplicationUrl");

        public PreviewYourAdvertOrVacancyPage(ScenarioContext context) : base(context) { }

        public DeleteVacancyQuestionPage DeleteVacancy()
        {
            formCompletionHelper.Click(DeleteVacancyButton);
            return new DeleteVacancyQuestionPage(context);
        }

        public EmployerVacancySearchResultPage ReturnToDashboard()
        {
            formCompletionHelper.Click(ReturnToDashboardLink);
            return new EmployerVacancySearchResultPage(context);
        }

        public ShortDescriptionPage AddBriefOverview()
        {
            formCompletionHelper.Click(BriefOverview);
            return new ShortDescriptionPage(context);
        }

        public DescriptionPage AddDescription()
        {
            formCompletionHelper.Click(VacancyDescription);
            return new DescriptionPage(context);
        }

        public DesiredSkillsPage AddSkills()
        {
            formCompletionHelper.Click(DesiredSkills);
            return new DesiredSkillsPage(context);
        }

        public QualificationsPage AddQualifications()
        {
            formCompletionHelper.Click(Qualifications);
            return new QualificationsPage(context);
        }

        public ApplicationProcessPage AddApplicationProcess()
        {
            formCompletionHelper.Click(ApplicationProcess);
            return new ApplicationProcessPage(context);
        }

        public EmployerDescriptionPage AddEmployerDescription()
        {
            formCompletionHelper.Click(EmployerDescription);
            return new EmployerDescriptionPage(context);
        }

        public ThingsToConsiderPage AddThingsToConsider()
        {
            formCompletionHelper.Click(ThingsToConsider);
            return new ThingsToConsiderPage(context);
        }

        public ContactDetailsPage AddContactDetails()
        {
            formCompletionHelper.Click(ContactDetails());
            return new ContactDetailsPage(context);
        }

        public VacancyReferencePage SubmitVacancy()
        {
            formCompletionHelper.Click(Submit);
            return new VacancyReferencePage(context);
        }

        public ResubmittedVacancyReferencePage ResubmitVacancy()
        {
            formCompletionHelper.Click(Submit);
            return new ResubmittedVacancyReferencePage(context);
        }

        public VacancyPreviewPart2WithErrorsPage SubmitVacancyWithMissingData()
        {
            formCompletionHelper.Click(Submit);
            return new VacancyPreviewPart2WithErrorsPage(context);
        }

        private By ContactDetails() => isRaaV2Employer ? EmployerContactDetails : ProviderContactDetails;

        public ApplicationProcessPage UpdateApplicationProcess()
        {
            if (pageInteractionHelper.IsElementPresent(ApplicationWebAddress)) formCompletionHelper.Click(ChangeApplicationProcess);
            else formCompletionHelper.Click(ApplicationProcess);

            return new ApplicationProcessPage(context);
        }
    }
}
