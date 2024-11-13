Feature: FAAWhatOnlySearch

User searches for a vacancy using what only search field

@faa
@raa
Scenario: FAA_USFV_01 User searches for a vacancy using 'What' only search field
	Given the candidate can login in to faa
	When the user does a what only search 'apprenticeship'
	Then the user is presented with search results
