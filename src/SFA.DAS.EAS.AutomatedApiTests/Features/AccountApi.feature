@SmokeTests	
Feature: AccountApiFeature
	
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
Scenario: Get all accounts
	Given A seeded set of accounts
	When I call the GetAccounts method
	Then I am returned a set of accounts

#//api/accounts/{hashedAccountId}
Scenario: Get account by hashed account id
	Given an account Id
	When I call the GetAccount method with a hashed account Id
	Then I am returned a single account

#//api/accounts/{hashedAccountId}/users	
Scenario: Get account users by hashed account id
	Given an account Id
	When I call the GetAccountsUsers method with a hashed account Id
	Then I am returned a set of users that belong to that account

#//api/accounts/{hashedAccountId}/payeschemes
Scenario: Get a PAYE Scheme by AccountId
	Given an account Id
	When I call the PayeSchemes method with a hashed account Id
	Then I am returned a set of PayeSchemes that belong to that account

#//api/accounts/{hashedAccountId}/transfersconnections
#Scenario: Get Transfers Connections by AccountId
#	Given an account Id
#	When I call the Transfers Connections method with a hashed account Id
#	Then I am returned a set of Transfers Connections that belong to that account