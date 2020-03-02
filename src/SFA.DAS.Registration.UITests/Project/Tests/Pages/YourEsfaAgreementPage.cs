using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourEsfaAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your ESFA agreement";
        private readonly ScenarioContext _context;

        #region Locators
        private By UpdateTheseDetailsLink => By.LinkText("Update these details");
        #endregion

        public YourEsfaAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReviewYourDetailsPage ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
        {
            formCompletionHelper.Click(UpdateTheseDetailsLink);
            return new ReviewYourDetailsPage(_context);
        }
    }
}
