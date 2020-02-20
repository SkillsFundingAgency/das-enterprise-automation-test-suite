Feature: RV1_CPS_01

Background: 
When an Applicant initiates Account creation journey
Then the Applicant is able to create a FAA Account

@raa-v1	
@apprenticeshipvacancy
@regression
@FAALoginNewCredentials
Scenario: RV1_CPS_01 - Changing Personal Setting in FAA and checking the changes in Recruit and Manage
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then the Provider is able to search and select a Candidate
	And the reviewer is able to search and select a candidate
	When the Candidate changes Personal Settings 
	Then the Candidate details is updated in Recruit
	And the Candidate details is updated in Manage