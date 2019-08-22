using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ApprovalsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
        }

        [Given(@"the User creates Employer account and sign an agreement")]
        public void GivenTheUserCreatesEmployerAccountAndSignAnAgreement()
        {
             new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding()
                .AddPaye()
                .ContinueToGGSignIn()
                .SignInTo()
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage()
                .ContinueWithAgreement()
                .SignAgreement();
        }
    }
}
