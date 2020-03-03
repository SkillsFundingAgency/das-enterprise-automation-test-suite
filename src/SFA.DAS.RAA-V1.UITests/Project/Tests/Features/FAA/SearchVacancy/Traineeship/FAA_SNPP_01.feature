Feature: FAA_SNPP_01
	

@raa-v1
@regression
Scenario: FAA_SNPP_01 - Search Vacancy when no partial postcode entered
Given an applicant is on the Find an Traineeship Page
Then an error message is displayed to the candidate when postcode is not valid 'CV'