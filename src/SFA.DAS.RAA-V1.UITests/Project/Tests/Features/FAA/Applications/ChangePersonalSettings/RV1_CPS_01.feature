Feature: RV1_CPS_01

Background: 
Given the Applicant creates new FAA account

@raa-v1	
@apprenticeshipvacancy
@regression
@FAALoginNewCredentials
Scenario: RV1_CPS_01 - Changing emailId and address in FAA and checking the changes in Recruit and Manage
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then the Provider is able to search and select a Candidate
	And the reviewer is able to search and select a candidate
	When the Candidate changes Personal Settings
	Then the Candidate details are updated in Recruit
	And the Candidate details is updated in Manage