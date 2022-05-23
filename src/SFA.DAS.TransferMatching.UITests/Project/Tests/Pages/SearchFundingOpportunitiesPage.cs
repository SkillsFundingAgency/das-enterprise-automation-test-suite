using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{

    public class Searchfundingopportunitiespage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Search funding opportunities";

        public Searchfundingopportunitiespage(ScenarioContext context) : base(context) { }

        private By AgricultureSelector => By.Id("Sectors");
        private By CareServicesSelector => By.Id("Sectors-3");
        private By CharitySelector => By.Id("Sectors-5");
        private By ProtectiveServicesSelector => By.Id("Sectors-14");
        private By TransportSelector => By.Id("Sectors-16");
        private By UpdateSelector => By.CssSelector("#opportunity-filter-sector");
        private By BusinessSectorSelector => By.XPath("/html/body/div[3]/main/div[2]/form/div[1]/details/summary");

        public Searchfundingopportunitiespage SelectAndApplyFilters()
        {
            formCompletionHelper.Click(BusinessSectorSelector);
            formCompletionHelper.SelectCheckbox(AgricultureSelector);
            formCompletionHelper.SelectCheckbox(CareServicesSelector);
            formCompletionHelper.SelectCheckbox(CharitySelector);
            formCompletionHelper.SelectCheckbox(ProtectiveServicesSelector);
            formCompletionHelper.SelectCheckbox(TransportSelector);
            formCompletionHelper.Click(UpdateSelector);
            return new Searchfundingopportunitiespage (context);
        }
    }
}


