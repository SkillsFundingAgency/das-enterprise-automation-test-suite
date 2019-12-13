using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ContactDetailsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Add contact information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EmployerContactName => By.CssSelector("#EmployerContactName");
        private By EmployerContactEmail => By.CssSelector("#EmployerContactEmail");
        private By EmployerContactPhone => By.CssSelector("#EmployerContactPhone");

        public ContactDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page EnterContactDetails()
        {
            _formCompletionHelper.EnterText(EmployerContactName, _dataHelper.EmployerContactName);
            _formCompletionHelper.EnterText(EmployerContactEmail, _dataHelper.EmployerEmail);
            _formCompletionHelper.EnterText(EmployerContactPhone, _dataHelper.EmployerContactNumber);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
    
    public class ThingsToConsiderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What else would you like the applicant to consider? (optional)";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ThingsToConsider => By.CssSelector("#ThingsToConsider");

        public ThingsToConsiderPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page EnterThingsToConsider()
        {
            _formCompletionHelper.EnterText(ThingsToConsider, _dataHelper.OptionalMessage);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
