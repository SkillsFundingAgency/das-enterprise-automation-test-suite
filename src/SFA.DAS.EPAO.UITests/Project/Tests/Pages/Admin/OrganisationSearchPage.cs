using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationSearchPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation search";

        private By OrganisationSearchField => By.Id("SearchString");

        public OrganisationSearchPage(ScenarioContext context) : base(context) => VerifyPage();

        public OrganisationSearchResultsPage SearchForAnOrganisation()
        {
            formCompletionHelper.EnterText(OrganisationSearchField, objectContext.GetOrganisationIdentifier());
            Continue();
            return new OrganisationSearchResultsPage(context);
        }
    } 
}
