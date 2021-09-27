using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransferMatchingSteps
    {

        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly TransferMatchingUser _transfersUser;
        private HomePage _homePage;

        public TransferMatchingSteps(ScenarioContext context)
        {
            _context = context;
            _transfersUser = context.GetUser<TransferMatchingUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
        }

        [Given(@"the Employer logins using existing Transfer Matching Account")]
        public void GivenTheEmployerLoginsUsingExistingTransferMatchingAccount() => Login(_transfersUser.OrganisationName);

        [Then(@"the Employer can create pledge using default criteria")]
        public void ThenTheEmployerCanCreatePledgeUsingDefaultCriteria()
        {
            new HomePageFinancesSection_YourTransfers(_context)
                .NavigateToTransferMatchingPage()
                .GotoCreateTransfersPledgePage()
                .StartCreatePledge()
                .EnterPledgeAmount();
        }


        [Then(@"the Employer can view transfers")]
        public void ThenTheEmployerCanViewTransfers()
        {
            new HomePageFinancesSection_YourTransfers(_context)
                .NavigateToTransferMatchingPage()
                .GoToViewMyTransferPledgePage();
        }

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _homePage = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }

    }
}
