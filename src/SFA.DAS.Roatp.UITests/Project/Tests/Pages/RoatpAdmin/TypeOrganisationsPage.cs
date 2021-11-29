using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class TypeOrganisationsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => $"Choose a type of organisation for {objectContext.GetProviderName()}";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        public TypeOrganisationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationDateDeterminedPage SubmitOrganisationType()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioInputs)));
            Continue();
            return new ApplicationDateDeterminedPage(_context);
        }
    }
}
