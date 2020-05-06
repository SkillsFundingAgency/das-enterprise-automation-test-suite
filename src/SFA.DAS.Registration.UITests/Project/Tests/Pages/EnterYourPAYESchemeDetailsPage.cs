using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourPAYESchemeDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your PAYE scheme details";
        private readonly ScenarioContext _context;

        #region Locators
        private By AornTextBox => By.Id("aorn");
        private By PayeRefTextBox => By.Id("payeRef");
        private By ErrorMessgeAboveAornTextBox => By.Id("error-message-aorn");
        private By ErrorMessgeAbovePayeTextBox => By.Id("error-message-payeRef");
        private By InvalidAornAndPayeErrorMessage => By.CssSelector(".govuk-error-message");
        private By SkipThisStepForNowLink => By.LinkText("Skip this step for now");
        protected override By ContinueButton => By.Id("submit-aorn-details");
        #endregion

        #region Constants
        public string BlankAornFieldErrorMessage => "Enter your reference number to continue";
        public string AornInvalidFormatErrorMessage => "Enter an accounts office reference number in the correct format";
        public string BlankPayeFieldErrorMessage => "Enter your PAYE scheme to continue";
        public string PayeInvalidFormatErrorMessage => "Enter a PAYE scheme number in the correct format";
        public string InvalidAornAndPayeErrorMessage1stAttempt => "You have 2 attempts remaining to enter a valid PAYE scheme and accounts office reference";
        public string InvalidAornAndPayeErrorMessage2ndAttempt => "You have 1 attempt remaining to enter a valid PAYE scheme and accounts office reference";
        #endregion

        public EnterYourPAYESchemeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckYourDetailsPage EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new CheckYourDetailsPage(_context);
        }

        public TheseDetailsAreAlreadyInUsePage ReEnterTheSameAornDetailsAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new TheseDetailsAreAlreadyInUsePage(_context);
        }

        public ChooseAnOrganisationPage EnterAornAndPayeDetailsForMultiOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new ChooseAnOrganisationPage(_context);
        }

        new public EnterYourPAYESchemeDetailsPage Continue()
        {
            base.Continue();
            return this;
        }

        private void EnterAornAndPayeAndContinue() => EnterAornAndPayeAndContinue(registrationDataHelper.AornNumber, objectContext.GetGatewayPaye(0));

        public void EnterAornAndPayeAndContinue(string aornNumber, string Paye)
        {
            formCompletionHelper.EnterText(AornTextBox, aornNumber);
            formCompletionHelper.EnterText(PayeRefTextBox, Paye);
            Continue();
        }

        public string GetErrorMessageAboveAornTextBox() => pageInteractionHelper.GetText(ErrorMessgeAboveAornTextBox);

        public string GetErrorMessageAbovePayeTextBox() => pageInteractionHelper.GetText(ErrorMessgeAbovePayeTextBox);

        public string GetInvalidAornAndPayeErrorMessage() => pageInteractionHelper.GetText(InvalidAornAndPayeErrorMessage);

        public MyAccountWithOutPayePage ClickSkipThisStepForNowLink()
        {
            formCompletionHelper.Click(SkipThisStepForNowLink);
            return new MyAccountWithOutPayePage(_context);
        }
    }
}