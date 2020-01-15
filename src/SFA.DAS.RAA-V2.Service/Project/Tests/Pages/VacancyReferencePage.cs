using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyReferencePage : BasePage
    {

        protected override By PageHeader => VacancyReferenceNumber;


        #region Helpers and Context
        private readonly VacancyReferenceHelper _vacancyReferenceHelper;
        #endregion

        protected override string PageTitle => "VAC";

        protected By VacancyReferenceNumber => By.CssSelector(".govuk-panel--confirmation strong");

        public VacancyReferencePage(ScenarioContext context) : base(context)
        {
            _vacancyReferenceHelper = context.Get<VacancyReferenceHelper>();
            VerifyPage();
        }

        public void SetVacancyReference()
        {
            _vacancyReferenceHelper.SetVacancyReference(VacancyReferenceNumber);
        }
    }
}
