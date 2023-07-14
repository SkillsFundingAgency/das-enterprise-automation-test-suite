using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourPAYESchemeDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Add PAYE details";

        #region Locators
        private static By AornTextBox => By.Id("aorn");
        private static By PayeRefTextBox => By.Id("payeRef");
        private static By ErrorMessgeAboveAornTextBox => By.Id("error-message-aorn");
        private static By ErrorMessgeAbovePayeTextBox => By.Id("error-message-payeRef");
        private static By InvalidAornAndPayeErrorMessage => By.CssSelector(".govuk-error-message");
        protected override By ContinueButton => By.Id("submit-aorn-details");
        #endregion

        #region Constants
        public string BlankAornFieldErrorMessage => "Enter your Accounts Office reference in the correct format";
        public string AornInvalidFormatErrorMessage => "Enter your Accounts Office reference in the correct format";
        public string BlankPayeFieldErrorMessage => "Enter your PAYE reference in the correct format";
        public string PayeInvalidFormatErrorMessage => "Enter your PAYE reference in the correct format";
        public string InvalidAornAndPayeErrorMessage1stAttempt => "You have 2 attempts remaining to enter a valid PAYE scheme and accounts office reference";
        public string InvalidAornAndPayeErrorMessage2ndAttempt => "You have 1 attempt remaining to enter a valid PAYE scheme and accounts office reference";
        #endregion

        public EnterYourPAYESchemeDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckYourDetailsPage EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new CheckYourDetailsPage(context);
        }

        public TheseDetailsAreAlreadyInUsePage ReEnterTheSameAornDetailsAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new TheseDetailsAreAlreadyInUsePage(context);
        }

        public ChooseAnOrganisationPage EnterAornAndPayeDetailsForMultiOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue();
            return new ChooseAnOrganisationPage(context);
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
    }
}