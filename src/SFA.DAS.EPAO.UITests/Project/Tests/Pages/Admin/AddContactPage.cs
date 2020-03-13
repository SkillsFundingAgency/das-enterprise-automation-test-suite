using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddContactPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "Add a contact";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstName => By.CssSelector("#FirstName");

        private By LastName => By.CssSelector("#LastName");

        private By Email => By.CssSelector("#Email");

        private By PhoneNumber => By.CssSelector("#PhoneNumber");
       
        public AddContactPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ContactDetailsPage AddContact()
        {
            formCompletionHelper.EnterText(FirstName, ePAOAdminDataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, ePAOAdminDataHelper.LastName);
            formCompletionHelper.EnterText(Email, ePAOAdminDataHelper.Email);
            formCompletionHelper.EnterText(PhoneNumber, ePAOAdminDataHelper.PhoneNumber);
            Continue();
            return new ContactDetailsPage(_context);
        }
    }
}
