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
        private By PayeDetailsLink(string paye) => By.XPath($"//td[contains(text(),'{paye}')]/following-sibling::td//a");
        private By PAYERemovedHeaderInfo => By.CssSelector("h2.govuk-error-summary__title");
        #endregion

        public PAYESchemesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UsingYourGovtGatewayDetailsPage ClickAddNewSchemeButton()
        {
            formCompletionHelper.Click(AddNewSchemeButton);
            return new UsingYourGovtGatewayDetailsPage(_context);
        }

        public PAYESchemeDetailsPage ClickPayeDetailsLink(string paye)
        {
            formCompletionHelper.Click(PayeDetailsLink(paye));
            return new PAYESchemeDetailsPage(_context);
        }

        public PAYESchemesPage VerifyPayeSchemeRemovedInfoMessage()
        {
            VerifyPage(PAYERemovedHeaderInfo, $"You've removed {objectContext.GetGatewayPaye(1)}");
            return this;
        }
    }
}
