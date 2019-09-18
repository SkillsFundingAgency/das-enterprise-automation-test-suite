using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransfersSteps
    {
        private readonly ScenarioContext _context;
        private readonly MongoDbDataGenerator _levyDeclarationHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;

        public TransfersSteps(ScenarioContext context)
        {
            _context = context;
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _levyDeclarationHelper = new MongoDbDataGenerator(_context);
        }

        [Given(@"the Employer has sufficient levy declarations for transfers")]
        public void GivenTheEmployerHasSufficientLevyDeclarationsForTransfers()
        {
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("18-19", "10", "72000", "99000", "2019-01-15");
            table.AddRow("18-19", "11", "82000", "99000", "2019-02-15");
            table.AddRow("18-19", "12", "92000", "99000", "2019-03-15");
            _levyDeclarationHelper.AddLevyDeclarations(1.00m, new DateTime(2019, 01, 15), table);
            _loginCredentialsHelper.SetIsLevy();
        }

        [Given(@"the User adds Receiver Employer account and sign an agreement")]
        public void GivenTheUserAddsReceiverEmployerAccountAndSignAnAgreement()
        {
            throw new PendingStepException();
        }


    }
}
