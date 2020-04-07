using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemesPage : RegistrationBasePage
    {
        protected override string PageTitle => "PAYE schemes";
        private readonly ScenarioContext _context;

        #region Locators
        private By AddNewSchemeButton => By.Id("addNewPaye");
        private By PayeDetailsLink => By.XPath($"//td[contains(text(),'{SecondPaye}')]/following-sibling::td//a");
        private By PAYERemovedHeaderInfo => By.CssSelector("h2.govuk-error-summary__title");
        private string SecondPaye => objectContext.GetGatewayPaye(1);
        #endregion

        public PAYESchemesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UsingYourGovtGatewayDetailsPage ClickAddNewSchemeButton()
        {
            formCompletionHelper.ClickInterceptedElement(pageInteractionHelper.FindElement(AddNewSchemeButton));
            return new UsingYourGovtGatewayDetailsPage(_context);
        }

        public PAYESchemeDetailsPage ClickNewlyAddedPayeDetailsLink()
        {
            formCompletionHelper.Click(PayeDetailsLink);
            return new PAYESchemeDetailsPage(_context);
        }

        public PAYESchemesPage VerifyPayeSchemeRemovedInfoMessage()
        {
            VerifyPage(PAYERemovedHeaderInfo, $"You've removed {SecondPaye}");
            return this;
        }
    }
}
