using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;

        public CreateAccountSteps(ScenarioContext context) => _context = context;

        [Then(@"user submits the details to create an account")]
        public void UserSubmitsTheDetailsToCreateAnAccount() => new RoatpApplyLoginHelpers(_context).CreateAnAccount();

        [Then(@"user submits the details to create an account")]
        public void UserSubmitsTheDetailsToCreateAnAccount(Table table)
        {
            _context.Get<RoatpApplyCreateUserDataHelper>().UpdateData(table.CreateInstance<RoatpApplyCreateUserDataHelper>());

            UserSubmitsTheDetailsToCreateAnAccount();
        }
    }
}
