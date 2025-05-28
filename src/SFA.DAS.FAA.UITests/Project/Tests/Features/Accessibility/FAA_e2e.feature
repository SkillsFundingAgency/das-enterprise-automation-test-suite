Feature: FAA_e2e_accessibility


@raa
@regression
@faa
@faaapplytestdataprep
Scenario: FAA_e2e_accessibility
	Given appretince creates an account
	When the user does a search without populating search fields
	Then the user is presented with search results
	And the user signs out
	And the candidate can login in to faa
	When the apprentice has submitted their first application
	Then the Applicant can view submitted applications page


