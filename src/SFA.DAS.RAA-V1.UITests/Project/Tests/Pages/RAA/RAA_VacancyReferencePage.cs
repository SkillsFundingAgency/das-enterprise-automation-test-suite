using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyReferencePage : RAA_HeaderSectionBasePage
    {
        protected override By PageHeader => VacancyReferenceNumber;

        protected override string PageTitle => "VAC";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By VacancyReferenceNumber => By.XPath("//strong[@class='heading-medium']");

        public RAA_VacancyReferencePage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage(VacancyReferenceNumber);
        }

        public string GetVacancyReference()
        {
            var referenceNumber = _pageInteractionHelper.GetText(VacancyReferenceNumber);
            return referenceNumber.Remove(0, 3);
        }
    }
}
