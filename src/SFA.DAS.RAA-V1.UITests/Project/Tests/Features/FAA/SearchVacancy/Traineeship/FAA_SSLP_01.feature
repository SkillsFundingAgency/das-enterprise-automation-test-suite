Feature: FAA_SSLP_01

@raa-v1
@regression
Scenario: FAA_SSLP_01 - Search Vacancy when single letter postcode entered
Given an applicant is on the Find an Traineeship Page
Then an error message is displayed to the candidate when postcode is not valid 'C'