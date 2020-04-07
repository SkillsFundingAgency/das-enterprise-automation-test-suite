using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemeAddedPage : RegistrationBasePage
    {
        protected override string PageTitle => $"{objectContext.GetGatewayPaye(1)} has been added";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By PageHeader => By.CssSelector(".bold-large");
        protected override By ContinueButton => By.CssSelector("button#accept");
        private By ContinueAccountSetupRadioButton => By.Id("choice3");
        #endregion

        public PAYESchemeAddedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage SelectContinueAccountSetupInPAYESchemeAddedPage()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ContinueAccountSetupRadioButton));
            Continue();
            return new HomePage(_context);
        }
    }
}
