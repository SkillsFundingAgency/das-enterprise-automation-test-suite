@SmokeTests	
Feature: AccountApiFeature

Background:
	Given I am authenticated with a token against the accounts Api
	
#//api/accounts
Scenario: Get all accounts
	Given A seeded set of accounts
	When I call the GetAccounts method
	Then I am returned a set of accounts

#//api/accounts/{hashedAccountId}
Scenario: Get account by hashed account id
	Given a hashed account Id
	When I call the GetAccount method with a hashed account Id
	Then I am returned a single account

#//api/accounts/{hashedAccountId}/users	
Scenario: Get account users by hashed account id
	Given a hashed account Id
	When I call the GetAccountsUsers method with a hashed account Id
	Then I am returned a set of users that belong to that account

#//api/accounts/internal/{accountId}
Scenario: Get account by accountId
	Given a hashed account Id
	When I call the GetAccount method with a hashed account Id
	And I call the internal GetAccount method with an accountId
	Then I am returned a single account


	## Need to be written
#//api/accounts/internal/{accountId}
#//api/accounts/internal/{accountId}/users
#//api/accountlegalentities
#//api/user/{userRef}/accounts
#//api/accounts/{hashedAccountId}/payeschems/{payeschemeref}



## Currently Won't Work
#//api/accounts/{hashedAccountId}/legalentities
Scenario: Get Legal Entities by hashed account id
	Given a hashed account Id
	When I call the legal entities endpoint with a hashed account id
	Then I am returned the legal entities that belong to that account

#//api/accounts/{HashedAccountId}/legalEntities/{hashedlegalEntityId}/agreements/{agreementId}
Scenario: Get Agreements for a hashed account id and hashed legal entity id
	Given a hashed account Id
	When I Call the agreements endpoint with an account id and legal entity id
	Then I am returned the agreements for that set of data

#//api/accounts/{hashedAccountId}/payeschemes
Scenario: Get a PAYE Scheme by AccountId
	Given a hashed account Id
	When I call the PayeSchemes method with a hashed account Id
	Then I am returned a set of PayeSchemes that belong to that account

#//api/accounts/{hashedAccountId}/transfersconnections
Scenario: Get Transfers Connections by AccountId
	Given a hashed account Id
	When I call the Transfers Connections method with a hashed account Id
	Then I am returned a set of Transfers Connections that belong to that account
