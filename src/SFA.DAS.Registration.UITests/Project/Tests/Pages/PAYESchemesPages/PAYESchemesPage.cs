using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemesPage : InterimPAYESchemesPage
    {
        private readonly ScenarioContext _context;

        #region Locators
        private By AddNewSchemeButton => By.Id("addNewPaye");
        private By PayeDetailsLink => By.XPath($"//td[contains(text(),'{SecondPaye}')]/following-sibling::td//a");
        private By PAYERemovedHeaderInfo => By.CssSelector("h3.das-notification__heading");
        private string SecondPaye => objectContext.GetGatewayPaye(1);
        #endregion

        public PAYESchemesPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            VerifyPage();
        }

        public UsingYourGovtGatewayDetailsPage ClickAddNewSchemeButton()
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(AddNewSchemeButton));
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
