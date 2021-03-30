using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyPreviewPart2Page : RAAV2CSSBasePage
    {
        protected override string PageTitle => _pageTitle ?? rAAV2DataHelper.VacancyTitle;
        private string _pageTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By ChangeClosingDateLink => By.CssSelector("a[data-automation='link-closing-date']");
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

        public VacancyPreviewPart2Page(ScenarioContext context, string pageTitle = null, bool verifypage = true) : base(context, false)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _pageTitle = pageTitle;

            if (verifypage) { VerifyPage(); }
        }

        public RAAV2CSSBasePage DeleteVacancy(string pageTitle = null, bool permissionDenied = false)
        {
            formCompletionHelper.Click(DeleteVacancyButton);

            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : new DeleteVacancyQuestionPage(_context, pageTitle) as RAAV2CSSBasePage;
        }

        public YourAdvertsPage ReturnToDashboard()
        {
            formCompletionHelper.Click(ReturnToDashboardLink);
            return new YourAdvertsPage(_context);
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

        public RAAV2CSSBasePage ChangeClosingDate(bool permissionDenied = false)
        {
            formCompletionHelper.Click(ChangeClosingDateLink);
            
            return permissionDenied 
                ? new DoNotHavePermissionBasePage(_context)
                : new ImportantDatesPage(_context) as RAAV2CSSBasePage;
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

        public RAAV2CSSBasePage SubmitVacancy(bool permissionDenied = false)
        {
            formCompletionHelper.Click(Submit);

            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : MissingData()
                    ? new VacancyPreviewPart2WithErrorsPage(_context, _pageTitle)
                    : new VacancyReferencePage(_context) as RAAV2CSSBasePage;
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

        public bool MissingData()
        {
            return _pageInteractionHelper.FindElement(PageHeaderM).Text != "You have completed all required sections";
        }

        private By ContactDetails() => _objectContext.IsRAAV2Employer() ? EmployerContactDetails : ProviderContactDetails;

        public ApplicationProcessPage UpdateApplicationProcess()
        {
            if (pageInteractionHelper.IsElementPresent(ApplicationWebAddress))
            {
                formCompletionHelper.Click(ChangeApplicationProcess);
            }
            else
            {
                formCompletionHelper.Click(ApplicationProcess);
            }
            return new ApplicationProcessPage(_context);
        }
    }
}
