using NUnit.Framework;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.UI.Framework;
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

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _applydataHelpers = context.Get<RoatpApplyDataHelpers>();
            _assertHelper = context.Get<AssertHelper>();
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(context.GetRoatpConfig<RoatpConfig>());
        }

        [Then(@"the Apply User is able to Create an Account")]
        public void ThenTheApplyUserIsAbleToCreateAnAccount()
        {
            string invitationId = string.Empty;

            string email = _applydataHelpers.CreateAccountEmail;

            new ServiceStartPage(_context)
                  .ClickApplyNow()
                  .SelectNoCreateAccountAndContinue()
                  .EnterAccountDetailsAndClickCreateAccount();

            _assertHelper.RetryOnNUnitException(() => 
            {
                invitationId = _loginInvitationsSqlDbHelper.GetId(email);

                Assert.IsNotEmpty(invitationId, $"Invitation id not found in the Login db for email '{email}'");
            });

            new CreatePasswordPage(_context).CreatePassword();
        }
    }
}
