using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeOrganisationTypePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change organisation type for {objectContext.GetProviderName()}";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChangeOrganisationTypePage(ScenarioContext context) : base(context) => _context = context;

        public ResultsFoundPage ConfirmNewOrganisationType()
        {
            formCompletionHelper.ClickElement(() => 
            {
                var randomElement = admindataHelpers.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs));
                objectContext.UpdateOrganisationType(randomElement?.Text);
                return randomElement;
            });
            Continue();
            return new ResultsFoundPage(_context);
        }
    }
}
