using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class TypeOrganisationsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"Choose a type of organisation for {objectContext.GetProviderName()}";

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        public TypeOrganisationsPage(ScenarioContext context) : base(context) { }

        public ApplicationDateDeterminedPage SubmitOrganisationType()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs)));
            Continue();
            return new ApplicationDateDeterminedPage(context);
        }
    }
}
