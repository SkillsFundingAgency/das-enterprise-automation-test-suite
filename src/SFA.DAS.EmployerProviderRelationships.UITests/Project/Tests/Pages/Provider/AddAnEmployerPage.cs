using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider
{
    public class AddAnEmployerPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
    {
        private static By StartNowButton => By.CssSelector(".govuk-button--start");

        protected override string PageTitle => "Add an employer";

        public SearchEmployerEmailPage StartNowToAddAnEmployer()
        {
            formCompletionHelper.Click(StartNowButton);

            return new(context);
        }

    }
}
