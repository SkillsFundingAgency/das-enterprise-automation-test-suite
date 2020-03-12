using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApprovalsStepsHelper _stepsHelper;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly ObjectContext _objectContext;

        public ApprovalsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _stepsHelper = new ApprovalsStepsHelper(context);
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
        }

        [Given(@"the User creates Employer account and sign an agreement")]
        public void TheUserCreatesEmployerAccountAndSignAnAgreement()
        {
            var emailId = _registrationDataHelper.RandomEmail;
            _objectContext.SetRegisteredEmail(emailId);
            TestContext.Progress.WriteLine($"Email : {emailId}");
            _stepsHelper.CreatesAccountAndSignAnAgreement();
        }
    }
}
