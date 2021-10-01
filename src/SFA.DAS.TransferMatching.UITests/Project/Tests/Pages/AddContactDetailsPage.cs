using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AddContactDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Add contact details";

        private readonly ScenarioContext _context;

        private By FirstNameSelector => By.CssSelector("#FirstName");
        private By LastNameSelector => By.CssSelector("#LastName");
        private By EmailAddressSelector => By.CssSelector("#EmailAddress");
        private By BusinessWebsiteSelector => By.CssSelector("#BusinessWebsite");

        protected override By ContinueButton => By.CssSelector("#application-contact-details");

        public AddContactDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransfersApplicationPage EnterContactDetailsAndContinue()
        {
            
            formCompletionHelper.EnterText(FirstNameSelector, datahelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameSelector, datahelper.ApprenticeLastname);
            formCompletionHelper.EnterText(EmailAddressSelector, datahelper.ApprenticeEmail);
            formCompletionHelper.EnterText(BusinessWebsiteSelector, "www.example.com");
            Continue();
            return new CreateATransfersApplicationPage(_context);
        }
    }
}