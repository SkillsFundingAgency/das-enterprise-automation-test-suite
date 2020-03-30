using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyPreviewPart2Page : RAAV2CSSBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

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

        public VacancyPreviewPart2Page(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public DeleteVacancyQuestionPage DeleteVacancy()
        {
            formCompletionHelper.Click(DeleteVacancyButton);
            return new DeleteVacancyQuestionPage(_context);
        }

        public VacanciesPage ReturnToDashboard()
        {
            formCompletionHelper.Click(ReturnToDashboardLink);
            return new VacanciesPage(_context);
        }

        public ShortDescriptionPage AddBriefOverview()
        {
            formCompletionHelper.Click(BriefOverview);
            return new ShortDescriptionPage(_context);
        }

        public DescriptionPage AddDescription()
        {
            formCompletionHelper.Click(VacancyDescription);
            return new DescriptionPage(_context);
        }

        public DesiredSkillsPage AddSkills()
        {
            formCompletionHelper.Click(DesiredSkills);
            return new DesiredSkillsPage(_context);
        }

        public QualificationsPage AddQualifications()
        {
            formCompletionHelper.Click(Qualifications);
            return new QualificationsPage(_context);
        }

        public ApplicationProcessPage AddApplicationProcess()
        {
            formCompletionHelper.Click(ApplicationProcess);
            return new ApplicationProcessPage(_context);
        }

        public EmployerDescriptionPage AddEmployerDescription()
        {
            formCompletionHelper.Click(EmployerDescription);
            return new EmployerDescriptionPage(_context);
        }

        public ThingsToConsiderPage AddThingsToConsider()
        {
            formCompletionHelper.Click(ThingsToConsider);
            return new ThingsToConsiderPage(_context);
        }

        public ContactDetailsPage AddContactDetails()
        {
            formCompletionHelper.Click(ContactDetails());
            return new ContactDetailsPage(_context);
        }

        public VacancyReferencePage SubmitVacancy()
        {
            formCompletionHelper.Click(Submit);
            return new VacancyReferencePage(_context);
        }

        public ResubmittedVacancyReferencePage ResubmitVacancy()
        {
            formCompletionHelper.Click(Submit);
            return new ResubmittedVacancyReferencePage(_context);
        }

        public VacancyPreviewPart2WithErrorsPage SubmitVacancyWithMissingData()
        {
            formCompletionHelper.Click(Submit);
            return new VacancyPreviewPart2WithErrorsPage(_context);
        }

        private By ContactDetails() => _objectContext.IsRAAV2Employer() ? EmployerContactDetails : ProviderContactDetails;
    }
}
