Feature: FAA_SBPC_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: FAA_SBPC_01 - Search Vacancy when single letter postcode entered
Given an applicant is on the Find an Apprenticeship Page
Then an error message is displayed to the candidate when postcode is not valid 'C'