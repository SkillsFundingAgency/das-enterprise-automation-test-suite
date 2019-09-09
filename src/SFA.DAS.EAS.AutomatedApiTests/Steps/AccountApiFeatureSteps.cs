using FluentAssertions;
using SFA.DAS.EAS.AutomatedApiTests.Helpers;
using SFA.DAS.EAS.AutomatedApiTests.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EAS.AutomatedApiTests.Steps
{
    [Binding]
    public class AccountApiFeatureSteps
    {
        private HttpClient accountClient;
        private AccountApiFeatureData accountApiFeatureData;
        public AccountApiFeatureSteps(AccountApiFeatureData accountApiFeatureData)
        {
            this.accountApiFeatureData = accountApiFeatureData;
        }

        [Given(@"I am authenticated with a token against the accounts Api")]
        public async Task GivenIAmAuthenticatedWithATokenAgainstTheAccountsApi()
        {
            accountClient = await AccountHelpers.GetAccountRestClient();
        }

        [When(@"I call the GetAccounts method")]
        public async Task WhenICallTheGetAccountsMethod()
        {
            var response = await accountClient.GetAsync("api/accounts");

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsAsync<PagedApiResponseWrapper<AccountWithBalanceViewModel>>();
                accountApiFeatureData.Accounts = results;
            }

        }

        [Then(@"I am returned a set of accounts")]
        public void ThenIAmReturnedASetOfAccounts()
        {
            var results = accountApiFeatureData.Accounts;
            results.Should().NotBeNull();
            results.Data.Should().NotBeNull();
            results.Data.Length.Should().Be(1000);
        }

        [Given(@"an account Id")]
        public void GivenAnAccountId()
        {
            accountApiFeatureData.HashedAccountId = AccountHelpers.GetHashedAccountId();
        }

        [When(@"I call the GetAccount method with a hashed account Id")]
        public async Task WhenICallTheGetAccountMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.HashedAccountId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<AccountDetail>();
                accountApiFeatureData.Account = result;
            }
        }

        [Then(@"I am returned a single account")]
        public void ThenIAmReturnedASingleAccount()
        {
            var result = accountApiFeatureData.Account;
            result.Should().NotBeNull();
            result.HashedAccountId.Should().Be(accountApiFeatureData.HashedAccountId);
        }

        [When(@"I call the GetAccountsUsers method with a hashed account Id")]
        public async Task WhenICallTheGetAccountsUsersMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.HashedAccountId}/users");

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsAsync<List<TeamMember>>();
                accountApiFeatureData.TeamMembers = results;
            }
        }

        [Then(@"I am returned a set of users that belong to that account")]
        public void ThenIAmReturnedASetOfUsersThatBelongToThatAccount()
        {
            var results = accountApiFeatureData.TeamMembers;
            results.Should().NotBeNull();
            results.Count.Should().Be(1);
            //results.Data[0].AccountHashId.Should().Be(ScenarioContext.Current["HashedAccountId"]);
        }
    }
}
