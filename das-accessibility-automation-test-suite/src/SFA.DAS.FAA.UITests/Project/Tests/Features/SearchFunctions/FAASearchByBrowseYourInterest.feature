Feature: FAASearchByBrowseYourInterest

User searches for a vacancy using Browse Your Interest

@faa
@raa
Scenario: FAA_USFV_01 User searches for a vacancy by Broswse Your Interests - city or postcode option
	Given the candidate can login in to faa
	When the user searches for vacancies by 'Enter a city or postcode' option in the Browse Your Interests route
	Then the user is presented with search results

@faa
@raa
Scenario: FAA_USFV_02 User searches for a vacancy by Broswse Your Interests - search across all of England option
	Given the candidate can login in to faa
	When the user searches for vacancies by 'Search across all of England' option in the Browse Your Interests route
	Then the user is presented with search results