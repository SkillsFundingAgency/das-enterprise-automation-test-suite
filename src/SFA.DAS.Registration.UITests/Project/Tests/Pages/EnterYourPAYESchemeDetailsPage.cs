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
        protected override By ContinueButton => By.Id("submit-aorn-details");
        #endregion

        #region Constants
        public const string BlankAornFieldErrorMessage = "Enter your reference number to continue";
        public const string AornInvalidFormatErrorMessage = "Enter an accounts office reference number in the correct format";
        public const string BlankPayeFieldErrorMessage = "Enter your PAYE scheme to continue";
        public const string PayeInvalidFormatErrorMessage = "Enter a PAYE scheme number in the correct format";
        #endregion

        public EnterYourPAYESchemeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckYourDetailsPage EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue(registrationDataHelper.AornNumber, objectContext.GetGatewayPaye());
            return new CheckYourDetailsPage(_context);
        }

        public TheseDetailsAreAlreadyInUsePage ReEnterTheSameAornDetailsAndContinue()
        {
            EnterAornAndPayeAndContinue(registrationDataHelper.AornNumber, objectContext.GetGatewayPaye());
            return new TheseDetailsAreAlreadyInUsePage(_context);
        }

        public ChooseAnOrganisationPage EnterAornAndPayeDetailsForMultiOrgScenarioAndContinue()
        {
            EnterAornAndPayeAndContinue(registrationDataHelper.AornNumber, objectContext.GetGatewayPaye());
            return new ChooseAnOrganisationPage(_context);
        }

        new public EnterYourPAYESchemeDetailsPage Continue()
        {
            base.Continue();
            return this;
        }

        public void EnterAornAndPayeAndContinue(string aornNumber, string Paye)
        {
            formCompletionHelper.EnterText(AornTextBox, aornNumber);
            formCompletionHelper.EnterText(PayeRefTextBox, Paye);
            Continue();
        }

        public string GetErrorMessgeAboveAornTextBox() => pageInteractionHelper.GetText(ErrorMessgeAboveAornTextBox);

        public string GetErrorMessgeAbovePayeTextBox() => pageInteractionHelper.GetText(ErrorMessgeAbovePayeTextBox);
    }
}