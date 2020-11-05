using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        private readonly RoatpApplyDataHelpers _applydataHelpers;
        private readonly AssertHelper _assertHelper;
        private readonly ObjectContext _objectContext;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _applydataHelpers = context.Get<RoatpApplyDataHelpers>();
            _assertHelper = context.Get<AssertHelper>();
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(context.GetRoatpConfig<RoatpConfig>());
        }

        [When(@"user submits the details to create an account")]
        public void WhenUserSubmitsTheDetailsToCreateAnAccount()
        {
            new ServiceStartPage(_context)
                .ClickApplyNow()
                .SelectNoCreateAccountAndContinue()
                .EnterAccountDetailsAndClickCreateAccount();
        }

        [Then(@"the user is able to create an account using the invitation")]
        public void ThenTheUserIsAbleToCreateAnAccountUsingTheInvitation()
        {
            string invitationId = string.Empty;

            string email = _applydataHelpers.CreateAccountEmail;

            string pasword = _applydataHelpers.Password;

            _assertHelper.RetryOnNUnitException(() =>
            {
                invitationId = _loginInvitationsSqlDbHelper.GetId(email);

                Assert.IsNotEmpty(invitationId, $"Invitation id not found in the Login db for email '{email}'");
            });

            new CreatePasswordPage(_context).CreatePassword(pasword);

            _objectContext.SetCreateAccountCreds(email, pasword);
        }
    }
}
