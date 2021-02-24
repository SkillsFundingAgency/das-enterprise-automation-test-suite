using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class SearchForATrainingProviderPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Search for an apprenticeship training provider";
        private By SearchTerm => By.CssSelector("#SearchTerm");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SearchForATrainingProviderPage(ScenarioContext context) : base(context) => _context = context;

        public TrainingProviderFoundPage SearchTrainingProvider()
        {
            formCompletionHelper.EnterText(SearchTerm, objectContext.GetUkprn());
            return new TrainingProviderFoundPage(_context);
        }
    }
}
