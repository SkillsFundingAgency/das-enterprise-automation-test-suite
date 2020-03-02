using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ReviewYourDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Review your details";
        private readonly ScenarioContext _context;

        #region Locators
        private By InfoText => By.CssSelector("h1 + p");
        protected override By RadioLabels => By.CssSelector("label");
        protected override By ContinueButton => By.Id("accept");
        #endregion

        public ReviewYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReviewYourDetailsPage VerifyInfoTextInReviewYourDetailsPage(string expectedText)
        {
            pageInteractionHelper.VerifyText(InfoText, expectedText);
            return this;
        }

        public DetailsUpdatedPage SelectUpdateMyDetailsRadioOptionAndContinueInReviewYourDetailsPage()
        {
            SelectRadioOptionByForAttribute("update");
            Continue();
            return new DetailsUpdatedPage(_context);
        }
    }
}