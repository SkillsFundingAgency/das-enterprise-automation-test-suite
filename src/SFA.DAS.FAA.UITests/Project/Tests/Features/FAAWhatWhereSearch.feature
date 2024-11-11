Feature: FAAWhatWhereSearch

User searches for a vacancy using search fields

@faa
@raa
Scenario: FAA_USFV_01 User searches for a vacancy using both 'What' and 'Where' search fields
	Given the candidate can login in to faa
	When the user does a what and where search 'apprenticeship','Coventry'
	Then the user is presented with search results
