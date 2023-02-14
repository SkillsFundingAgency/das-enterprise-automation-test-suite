using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin
{
    public class SearchPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship training provider";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By Confirmation => By.CssSelector(".govuk-panel--confirmation");

        private By ProviderSearch => By.Id("SearchTerm");

        public SearchPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchPage VerifyNewProviderHasBeenAdded()
        {
            pageInteractionHelper.VerifyText(Confirmation, $"{objectContext.GetProviderName()} has been added");
            return this;
        }

        public ResultsFoundPage SearchTrainingProviderByName() => SearchTrainingProvider(objectContext.GetProviderName());

        public ResultsFoundPage SearchTrainingProviderByUkprn() => SearchTrainingProvider(objectContext.GetUkprn());

        public ResultsFoundPage SearchTrainingProvider(string text)
        {
            formCompletionHelper.EnterText(ProviderSearch, text);
            Continue();
            return new ResultsFoundPage(context);
        }
        public RoatpAdminHomePage ReturnToDahsboard()
        {
            formCompletionHelper.ClickLinkByText("Dashboard");
            return new RoatpAdminHomePage(context);
        }
    }
}
