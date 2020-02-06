using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Check your details";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.Id("continue");
        #endregion

        public CheckYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhenDoYouWantToViewEmpAgreementPage ContinueToAboutYourAgreementPage()
        {
            Continue();
            return new WhenDoYouWantToViewEmpAgreementPage(_context);
        }
    }
}