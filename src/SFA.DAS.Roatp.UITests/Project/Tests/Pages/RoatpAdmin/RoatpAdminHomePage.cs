using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class RoatpAdminHomePage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship training provider";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Confirmation => By.CssSelector(".govuk-panel--confirmation");

        private By ProviderSearch => By.Id("SearchTerm");

        public RoatpAdminHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public OrganisationUkprnPage AddANewTrainingProvider()
        {
            formCompletionHelper.ClickLinkByText("Add a new training provider");
            return new OrganisationUkprnPage(_context);
        }

        public RoatpAdminHomePage DownloadRegister()
        {
            formCompletionHelper.ClickLinkByText("Download list of training providers");
            return new RoatpAdminHomePage(_context);
        }

        public bool VerifyNewProviderHasBeenAdded() => pageInteractionHelper.VerifyText(Confirmation, $"{objectContext.GetProviderName()} has been added");

        public ResultsFoundPage SearchTrainingProviderByName() => SearchTrainingProvider(objectContext.GetProviderName());

        public ResultsFoundPage SearchTrainingProviderByUkprn() => SearchTrainingProvider(objectContext.GetUkprn());

        public ResultsFoundPage SearchTrainingProvider(string text)
        {
            formCompletionHelper.EnterText(ProviderSearch, text);
            Continue();
            return new ResultsFoundPage(_context);
        }
    }
}
