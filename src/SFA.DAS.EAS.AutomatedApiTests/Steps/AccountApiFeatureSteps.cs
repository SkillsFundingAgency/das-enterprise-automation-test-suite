using FluentAssertions;
using SFA.DAS.EAS.AutomatedApiTests.ApiModels;
using SFA.DAS.EAS.AutomatedApiTests.Database;
using SFA.DAS.EAS.AutomatedApiTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Given(@"A seeded set of accounts")]
        public void GivenASeededSetOfAccounts()
        {
            accountApiFeatureData.SeedData.SeededAccounts = SeedData.SeedAccounts;
        }

        [When(@"I call the GetAccounts method")]
        public async Task WhenICallTheGetAccountsMethod()
        {
            var response = await accountClient.GetAsync("api/accounts");

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsAsync<PagedApiResponseWrapper<AccountWithBalanceViewModel>>();
                accountApiFeatureData.ApiResponseData.Accounts = results;
            }

        }

        [Then(@"I am returned a set of accounts")]
        public void ThenIAmReturnedASetOfAccounts()
        {
            var results = accountApiFeatureData.ApiResponseData.Accounts;
            results.Should().NotBeNull();
            results.Data.Should().NotBeNull();
            results.Data.Length.Should().BeGreaterOrEqualTo(accountApiFeatureData.SeedData.SeededAccounts.Count);
        }

        [Given(@"a hashed account Id")]
        public void GivenAHashedAccountId()
        {
            var seedAccount = SeedData.SeedAccounts.First();
            accountApiFeatureData.SeedData.SeedAccount = seedAccount;
            accountApiFeatureData.SeedData.HashedAccountId = seedAccount.AccountHashedId;
        }

        [When(@"I call the GetAccount method with a hashed account Id")]
        public async Task WhenICallTheGetAccountMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<AccountDetail>();
                accountApiFeatureData.ApiResponseData.Account = result;
                accountApiFeatureData.ApiResponseData.AccountId = result.AccountId;
            }
        }

        [Then(@"I am returned a single account")]
        public void ThenIAmReturnedASingleAccount()
        {
            var result = accountApiFeatureData.ApiResponseData.Account;
            var expectedAccount = accountApiFeatureData.SeedData.SeedAccount;
            result.Should().NotBeNull();
            result.HashedAccountId.Should().Be(expectedAccount.AccountHashedId);
            result.DasAccountName.Should().Be(expectedAccount.LegalEntityName);
            result.DateRegistered.Should().BeCloseTo(DateTime.Now, 20000);
            result.PublicHashedAccountId.Should().Be(expectedAccount.AccountPublicHashedId);
            result.OwnerEmail.Should().Be(expectedAccount.UserEmailAddress);
            result.AccountAgreementType.Should().Be(AccountAgreementType.Levy);
            result.LegalEntities.Count.Should().Be(1);
            result.LegalEntities.First().Href.Should().Contain(expectedAccount.AccountHashedId);
        }

        [When(@"I call the GetAccountsUsers method with a hashed account Id")]
        public async Task WhenICallTheGetAccountsUsersMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}/users");

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsAsync<List<TeamMember>>();
                accountApiFeatureData.ApiResponseData.TeamMembers = results;
            }
        }

        [Then(@"I am returned a set of users that belong to that account")]
        public void ThenIAmReturnedASetOfUsersThatBelongToThatAccount()
        {
            var results = accountApiFeatureData.ApiResponseData.TeamMembers;
            var expectedAccount = accountApiFeatureData.SeedData.SeedAccount;
            var expectedName = string.Concat(expectedAccount.UserFirstName, " ", expectedAccount.UserLastName);
            results.Should().NotBeNull();
            results.Count.Should().Be(1);
            var user = results.First();
            user.Email.Should().Be(expectedAccount.UserEmailAddress);
            user.Name.Should().Be(expectedName);
            user.Role.Should().Be("Owner");
            user.Status.Should().Be(TeamMember.InvitationStatus.Accepted);
        }

        [When(@"I call the internal GetAccount method with an accountId")]
        public async Task WhenICallTheInternalGetAccountMethodWithAnAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/internal/{accountApiFeatureData.ApiResponseData.AccountId}");

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                // This won't work because it requires a decoded hash value.
            }
        }


        [When(@"I call the legal entities endpoint with a hashed account id")]
        public async Task WhenICallTheLegalEntitiesEndpointWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}/legalentities");

            if (response.IsSuccessStatusCode)
            {
                // This won't work because it requires a decoded hash value.
            }
        }

        [Then(@"I am returned the legal entities that belong to that account")]
        public void ThenIAmReturnedTheLegalEntitiesThatBelongToThatAccount()
        {
            accountApiFeatureData.ApiResponseData.Account.Should().NotBeNull();
        }

        [When(@"I Call the agreements endpoint with an account id and legal entity id")]
        public async Task WhenICallTheAgreementsEndpointWithAnAccountIdAndLegalEntityId()
        {
            //api/accounts/{HashedAccountId}/legalEntities/{hashedlegalEntityId}/agreements/{agreementId}
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}/legalentities/{accountApiFeatureData.SeedData.SeedAccount.PublicHashId}/agreements/");

            if (response.IsSuccessStatusCode)
            {
                // This won't work because it requires a decoded hash value plus the agreement id from a separate call
            }
        }

        [Then(@"I am returned the agreements for that set of data")]
        public void ThenIAmReturnedTheAgreementsForThatSetOfData()
        {
            accountApiFeatureData.ApiResponseData.Account.Should().NotBeNull();
        }        

        [When(@"I call the PayeSchemes method with a hashed account Id")]
        public async Task WhenICallThePayeSchemesMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}/payeschemes");

            if (response.IsSuccessStatusCode)
            {
                // This won't work because it requires a decoded hash value. 
            }
        }

        [Then(@"I am returned a set of PayeSchemes that belong to that account")]
        public void ThenIAmReturnedASetOfPayeSchemesThatBelongToThatAccount()
        {
            var results = accountApiFeatureData.ApiResponseData.PayeSchemesResourceList;
            results.Should().NotBeNull();
        }

        [When(@"I call the Transfers Connections method with a hashed account Id")]
        public async Task WhenICallTheTransfersConnectionsMethodWithAHashedAccountId()
        {
            var response = await accountClient.GetAsync($"api/accounts/{accountApiFeatureData.SeedData.HashedAccountId}/transfers/connections");

            if (response.IsSuccessStatusCode)
            {
                // This won't work because it requires a decoded hash value.
            }
        }

        [Then(@"I am returned a set of Transfers Connections that belong to that account")]
        public void ThenIAmReturnedASetOfTransfersConnectionsThatBelongToThatAccount()
        {
            var results = accountApiFeatureData.ApiResponseData.PayeSchemesResourceList;
            results.Should().NotBeNull();
        }


    }
}
