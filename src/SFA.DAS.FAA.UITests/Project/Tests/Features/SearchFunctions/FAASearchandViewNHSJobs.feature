Feature: FAASearchandViewNHSJobs

@faa
@raa
@regression
@raaprovider
Scenario: FAA_USFV_01 User searches for a vacancy using 'What' only search field
	Given the candidate can login in to faa
	When the user does a what only search 'NHS'
	Then the user is presented with search results
	And the user is able to view NHS job displayed