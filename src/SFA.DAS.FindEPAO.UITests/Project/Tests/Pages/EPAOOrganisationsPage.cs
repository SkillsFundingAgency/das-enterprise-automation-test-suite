using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class EPAOOrganisationsPage : FindEPAOBasePage
    {
        protected override string PageTitle => "end-point assessment organisations";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private readonly ScenarioContext _context;
        public EPAOOrganisationsPage(ScenarioContext context) : base(context) => _context = context;

        public EPAOOrganisationDetailsPage SelectFirstEPAOOrganisationFromList()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetEPAOOrganisationName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new EPAOOrganisationDetailsPage(_context);
        }
    }
}
