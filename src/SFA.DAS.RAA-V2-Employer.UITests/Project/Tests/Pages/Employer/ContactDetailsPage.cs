using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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
            formCompletionHelper.EnterText(EmployerContactName, dataHelper.EmployerContactName);
            formCompletionHelper.EnterText(EmployerContactEmail, dataHelper.EmployerEmail);
            formCompletionHelper.EnterText(EmployerContactPhone, dataHelper.EmployerContactNumber);
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
