using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyReferencePage : BasePage
    {
        protected override By PageHeader => VacancyReferenceNumber;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly VacancyReferenceHelper _vacancyReferenceHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        protected override string PageTitle => "VAC";

        protected By VacancyReferenceNumber => By.CssSelector(".govuk-panel--confirmation strong");

        protected By ReturnToDashboard => By.LinkText("Return to dashboard");

        public VacancyReferencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _vacancyReferenceHelper = context.Get<VacancyReferenceHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void SetVacancyReference()
        {
            _vacancyReferenceHelper.SetVacancyReference(VacancyReferenceNumber);
        }
    }
}
