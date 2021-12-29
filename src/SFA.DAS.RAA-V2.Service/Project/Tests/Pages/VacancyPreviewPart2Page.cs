using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyPreviewPart2Page : RAAV2CSSBasePage
    {
        protected override string PageTitle => rAAV2DataHelper.VacancyTitle;

        protected override bool TakeFullScreenShot => false;

        private By BriefOverview => By.CssSelector("a[data-automation='link-overview']");
        private By VacancyDescription => By.CssSelector("a[data-automation='link-vacancy-description']");
        private By DesiredSkills => By.CssSelector("a[data-automation='link-skills']");
        private By Qualifications => By.CssSelector("a[data-automation= 'link-qualifications']");
        private By EmployerDescription => By.CssSelector("a[data-automation='link-description']");
        private By ApplicationProcess => By.CssSelector("a[data-automation='link-application-method']");
        private By ThingsToConsider => By.CssSelector("a[data-automation='link-things-to-consider']");
        private By EmployerContactDetails => By.CssSelector("a[data-automation='link-employer-contact-details']");
        private By ProviderContactDetails => By.CssSelector("a[data-automation='link-provider-contact-details']");
        private By Submit => By.CssSelector(".govuk-button[data-automation='submit-button']");
        private By ReturnToDashboardLink => By.CssSelector("a[data-automation='dashboard-link']");
        private By DeleteVacancyButton => By.CssSelector("a[data-automation='delete-button']");
        private By ChangeApplicationProcess => By.CssSelector("a[data-automation='link-application-link']");
        private By ApplicationWebAddress => By.Id("ApplicationUrl");

        public VacancyPreviewPart2Page(ScenarioContext context) : base(context) { }

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

        private By ContactDetails() => objectContext.IsRAAV2Employer() ? EmployerContactDetails : ProviderContactDetails;

        public ApplicationProcessPage UpdateApplicationProcess()
        {
            if (pageInteractionHelper.IsElementPresent(ApplicationWebAddress)) formCompletionHelper.Click(ChangeApplicationProcess);                
            else formCompletionHelper.Click(ApplicationProcess);
            
            return new ApplicationProcessPage(context);
        }
    }
}
