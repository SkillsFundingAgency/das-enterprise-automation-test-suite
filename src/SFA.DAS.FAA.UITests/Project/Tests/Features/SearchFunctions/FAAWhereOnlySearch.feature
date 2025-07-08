Feature: FAAWhereOnlySearch

User searches for a vacancy using where only search field

@faa
@raa
@regression
@raaprovider
Scenario: FAA_USFV_01 User searches for a vacancy using 'Where' only search field
	Given the candidate can login in to faa
	When the user does a where only search 'Coventry'
	Then the user is presented with search results
