@SmokeTests	
Feature: AccountApiFeature
	#//api/accounts/{hashedAccountId}/transfersconnections
	#//api/accounts/{hashedAccountId}/payeschemes
	#//api/accounts/{hashedAccountId}/payeschems/{payeschemeref}
	#//api/accounts/{hashedAccountId}/legalentities
	#//api/accounts/{HashedAccountId}/legalEntities/{hashedlegalEntityId}/agreements/{agreementId}
	#//api/accounts/internal/{accountId}
	#//api/accounts/internal/{accountId}/users
	#//api/accountlegalentities
	#//api/user/{userRef}/accounts

Background:
	Given I am authenticated with a token against the accounts Api

#//api/accounts
Scenario: Get All Accounts
	When I call the GetAccounts method
	Then I am returned a set of accounts

#//api/accounts/{hashedAccountId}
Scenario: Successfully retrieve an Account by hashed account id
	Given an account Id
	When I call the GetAccount method with a hashed account Id
	Then I am returned a single account

#//api/accounts/{hashedAccountId}/users	
Scenario: Get Account Users
	Given an account Id
	When I call the GetAccountsUsers method with a hashed account Id
	Then I am returned a set of users that belong to that account