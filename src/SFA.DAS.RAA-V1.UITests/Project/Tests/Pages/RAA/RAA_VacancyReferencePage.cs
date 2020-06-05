using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyReferencePage : RAA_VacancyReferenceBasePage
    {
        protected override By PageHeader => VacancyReferenceNumber;

        protected override string PageTitle => "VAC";
        
        protected override By VacancyReferenceNumber => By.XPath("//strong[@class='heading-medium']");

        public RAA_VacancyReferencePage(ScenarioContext context) : base(context)
        {
            VerifyPage(VacancyReferenceNumber);
        }
    }
}
