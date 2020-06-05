using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ContactDetailsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Add contact information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        protected By EmployerContactName => By.CssSelector("#EmployerContactName");
        protected By EmployerContactEmail => By.CssSelector("#EmployerContactEmail");
        protected By EmployerContactPhone => By.CssSelector("#EmployerContactPhone");

        protected By ProviderContactName => By.CssSelector("#ProviderContactName");
        protected By ProviderContactEmail => By.CssSelector("#ProviderContactEmail");
        protected By ProviderContactPhone => By.CssSelector("#ProviderContactPhone");

        public ContactDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public VacancyPreviewPart2Page EnterContactDetails()
        {
            formCompletionHelper.EnterText(ContactName(), rAAV2DataHelper.ContactName);
            formCompletionHelper.EnterText(ContactEmail(), rAAV2DataHelper.Email);
            formCompletionHelper.EnterText(ContactPhone(), rAAV2DataHelper.ContactNumber);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }

        private By ContactName() => _objectContext.IsRAAV2Employer() ? EmployerContactName : ProviderContactName;
        private By ContactEmail() => _objectContext.IsRAAV2Employer() ? EmployerContactEmail : ProviderContactEmail;
        private By ContactPhone() => _objectContext.IsRAAV2Employer() ? EmployerContactPhone : ProviderContactPhone;

    }
}
