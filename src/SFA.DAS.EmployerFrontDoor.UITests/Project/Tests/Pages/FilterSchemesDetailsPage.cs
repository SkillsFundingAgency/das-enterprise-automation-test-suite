using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
    public class FilterSchemesDetailsPage : EmployerFrontDoorHeaderBasePage
    {
        private readonly ScenarioContext _context;

        private By FilterSchemesButton => By.Id("filter-schemes");
        private By SelCheckBoxOne => By.Id("motivations--full-time-role");
        private By SelCheckBoxTwo => By.Id("motivations--unpaid-placement");
        private By SelCheckBoxThree => By.Id("motivations--diversity-or-responsibility");
        private By SelCheckBoxFour => By.Id("scheme-length--up-to-4-months");
        private By SelCheckBoxFive => By.Id("scheme-length--4-months-to-12-months");
        private By SelCheckBoxSix => By.Id("scheme-length--a-year-or-more");
        private By SelCheckBoxSeven => By.Id("pay--minimum-wage");
        private By SelCheckBoxEight => By.Id("pay--unpaid");
        private By ClearAllFilters => By.Id("clear-filters");

        public FilterSchemesDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public FilterSchemesDetailsPage FilterScheme()
        {
            {
                formCompletionHelper.ClickElement(FilterSchemesButton);
                formCompletionHelper.SelectCheckbox(SelCheckBoxOne);
                formCompletionHelper.SelectCheckbox(SelCheckBoxTwo);
                formCompletionHelper.SelectCheckbox(SelCheckBoxThree);
                formCompletionHelper.SelectCheckbox(SelCheckBoxFour);
                formCompletionHelper.SelectCheckbox(SelCheckBoxFive);
                formCompletionHelper.SelectCheckbox(SelCheckBoxSix);
                formCompletionHelper.SelectCheckbox(SelCheckBoxSeven);
                formCompletionHelper.SelectCheckbox(SelCheckBoxEight);
                formCompletionHelper.SelectCheckbox(ClearAllFilters);
            }
            return new FilterSchemesDetailsPage(_context);
        }
    }
}