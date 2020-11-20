using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyLoginHelpers _roatpApplyLoginHelpers;
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        private readonly RoatpApplyCreateUserDataHelpers _applydataHelpers;
        private readonly AssertHelper _assertHelper;
        private readonly ObjectContext _objectContext;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _applydataHelpers = context.Get<RoatpApplyCreateUserDataHelpers>();
            _assertHelper = context.Get<AssertHelper>();
            _roatpApplyLoginHelpers = new RoatpApplyLoginHelpers(context);
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(context.GetRoatpConfig<RoatpConfig>());
        }

        [When(@"user submits the details to create an account")]
        public void WhenUserSubmitsTheDetailsToCreateAnAccount() => _roatpApplyLoginHelpers.CreateAnAccountPage().EnterAccountDetailsAndClickCreateAccount();

        [When(@"user submits the details to create an account")]
        public void WhenUserSubmitsTheDetailsToCreateAnAccount(Table table)
        {
            var row = table.CreateInstance<RoatpApplyCreateUserDataHelpers>();

            _applydataHelpers.GivenName = row.GivenName;
            var familyname = $"{row.FamilyName}{DateTime.Now:ddMMMyyyy_HHmmss}";
            _applydataHelpers.FamilyName = familyname;
            _applydataHelpers.CreateAccountEmail = $"{row.GivenName}{familyname}@digital.education.gov.uk";
            _applydataHelpers.Password = "RoatpAutomation123";

            _roatpApplyLoginHelpers.CreateAnAccountPage().EnterAccountDetailsAndClickCreateAccount();
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
