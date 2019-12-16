using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class VacancyPreviewPart2Page : RAAV2CSSBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By BriefOverview => By.CssSelector("a[data-automation='link-overview']");
        private By VacancyDescription => By.CssSelector("a[data-automation='link-vacancy-description']");
        private By DesiredSkills => By.CssSelector("a[data-automation='link-skills']");
        private By Qualifications => By.CssSelector("a[data-automation= 'link-qualifications']");
        private By EmployerDescription => By.CssSelector("a[data-automation='link-description']");
        private By ApplicationProcess => By.CssSelector("a[data-automation='link-application-method']");
        private By ThingsToConsider => By.CssSelector("a[data-automation='link-things-to-consider']");
        private By ContactDetails => By.CssSelector("a[data-automation='link-employer-contact-details']");
        private By Submit => By.CssSelector(".govuk-button[data-automation='submit-button']");


        public VacancyPreviewPart2Page(ScenarioContext context) : base(context)
        {
            _context = context;
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
            formCompletionHelper.Click(ContactDetails);
            return new ContactDetailsPage(_context);
        }

        public VacancyReferencePage SubmitVacancy()
        {
            formCompletionHelper.Click(Submit);
            return new VacancyReferencePage(_context);
        }
    }
}
