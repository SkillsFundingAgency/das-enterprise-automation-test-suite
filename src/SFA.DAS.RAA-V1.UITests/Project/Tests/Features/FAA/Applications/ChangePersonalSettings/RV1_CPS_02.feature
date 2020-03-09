Feature: RV1_CPS_02
	
Background: 
Given the Applicant creates new FAA account

@raa-v1	
@apprenticeshipvacancy
@regression
@FAALoginNewCredentials
Scenario: RV1_CPS_01 - Changing PhoneNumber in FAA and checking the changes in Recruit and Manage
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then the Provider is able to search and select a Candidate
	And the reviewer is able to search and select a candidate
	When the Candidate changes Personal Settings 'PhoneNumber'
	Then the Candidate details is updated in Recruit 'PhoneNumber'


