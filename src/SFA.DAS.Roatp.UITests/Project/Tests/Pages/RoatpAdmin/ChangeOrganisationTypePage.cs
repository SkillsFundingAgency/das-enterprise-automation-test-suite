using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeOrganisationTypePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change organisation type for {objectContext.GetProviderName()}";

        public ChangeOrganisationTypePage(ScenarioContext context) : base(context) { }

        public ResultsFoundPage ConfirmNewOrganisationType()
        {
            formCompletionHelper.ClickElement(() => 
            {
                var randomElement = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs));
                objectContext.UpdateOrganisationType(randomElement?.Text);
                return randomElement;
            });
            Continue();
            return new ResultsFoundPage(context);
        }
    }
}
