using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{

    public class Searchfundingopportunitiespage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Search funding opportunities";

        public Searchfundingopportunitiespage(ScenarioContext context) : base(context) { }

        private static By AgricultureSelector => By.Id("Sectors");
        private static By CareServicesSelector => By.Id("Sectors-3");
        private static By CharitySelector => By.Id("Sectors-5");
        private static By ProtectiveServicesSelector => By.Id("Sectors-14");
        private static By TransportSelector => By.Id("Sectors-16");
        private static By UpdateSelector => By.CssSelector("#opportunity-filter-sector");
        private static By BusinessSectorSelector => By.XPath("/html/body/div[3]/main/div[2]/form/div[1]/details/summary");

        public Searchfundingopportunitiespage SelectAndApplyFilters()
        {
            formCompletionHelper.Click(BusinessSectorSelector);
            formCompletionHelper.SelectCheckbox(AgricultureSelector);
            formCompletionHelper.SelectCheckbox(CareServicesSelector);
            formCompletionHelper.SelectCheckbox(CharitySelector);
            formCompletionHelper.SelectCheckbox(ProtectiveServicesSelector);
            formCompletionHelper.SelectCheckbox(TransportSelector);
            formCompletionHelper.Click(UpdateSelector);
            return new Searchfundingopportunitiespage(context);
        }
    }
}


