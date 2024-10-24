using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class ViewEmpAndManagePermissionsPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
    {
        private static By AddAnEmployerSelector => By.LinkText("Add an employer");

        private static By SearchTerm => By.CssSelector("input#SearchTerm");

        private static By HasPendingRequest => By.CssSelector(".govuk-checkboxes__label[for='HasPendingRequest']");

        private static By ApplyFilter => By.CssSelector("button[id='filters-submit-second'][type='submit']");

        private static By EmpLinks => By.CssSelector("a.govuk-link.app-search-result-link");

        protected override string PageTitle => "View employers and manage permissions";

        public AddAnEmployerPage ClickAddAnEmployer()
        {
            formCompletionHelper.Click(AddAnEmployerSelector);

            return new(context);
        }

        public EmployerAccountDetailsPage ViewEmployer()
        {
            formCompletionHelper.EnterText(SearchTerm, eprDataHelper.EmployerName);

            formCompletionHelper.Click(ApplyFilter);

            formCompletionHelper.Click(By.CssSelector($"a[href*='{eprDataHelper.AgreementId}']"));

            return new(context);
        }

        public void VerifyPendingRequest()
        {
            formCompletionHelper.Click(HasPendingRequest);

            formCompletionHelper.Click(ApplyFilter);

            VerifyFromMultipleElements(EmpLinks, eprDataHelper.EmployerName);
        }
    }
}
