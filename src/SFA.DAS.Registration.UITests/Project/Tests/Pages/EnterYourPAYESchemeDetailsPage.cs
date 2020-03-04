using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourPAYESchemeDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your PAYE scheme details";
        private readonly ScenarioContext _context;
        private readonly string _payeSchemeReference;

        #region Locators
        private By AornTextBox => By.Id("aorn");
        private By PayeRefTextBox => By.Id("payeRef");
        protected override By ContinueButton => By.Id("submit-aorn-details");
        #endregion

        public EnterYourPAYESchemeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _payeSchemeReference = context.Get<ObjectContext>().GetGatewayPaye();
            VerifyPage();
        }

        public CheckYourDetailsPage EnterAornAndPayeDetailsAndContinue(string aornNumber)
        {
            formCompletionHelper.EnterText(AornTextBox, aornNumber);
            formCompletionHelper.EnterText(PayeRefTextBox, _payeSchemeReference);
            Continue();
            return new CheckYourDetailsPage(_context);
        }
    }
}