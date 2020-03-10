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
        protected override By ContinueButton => By.Id("submit-aorn-details");
        #endregion

        public EnterYourPAYESchemeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckYourDetailsPage EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue()
        {
            EnterPayeData();
            return new CheckYourDetailsPage(_context);
        }

        public TheseDetailsAreAlreadyInUsePage ReEnterTheSameAornDetailsAndContinue()
        {
            EnterPayeData();
            return new TheseDetailsAreAlreadyInUsePage(_context);
        }

        public ChooseAnOrganisationPage EnterAornAndPayeDetailsForMultiOrgScenarioAndContinue()
        {
            EnterPayeData();
            return new ChooseAnOrganisationPage(_context);
        }

        private void EnterPayeData()
        {
            formCompletionHelper.EnterText(AornTextBox, registrationDataHelper.AornNumber);
            formCompletionHelper.EnterText(PayeRefTextBox, objectContext.GetGatewayPaye());
            Continue();
        }
    }
}