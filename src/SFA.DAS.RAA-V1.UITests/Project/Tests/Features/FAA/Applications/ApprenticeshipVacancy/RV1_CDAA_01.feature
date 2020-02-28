Feature: RV1_CDAA_01
	
Background: 
	When an Applicant initiates Account creation journey
	Then the Applicant is able to create a FAA Account
@apprenticeshipvacancy
@regression
@raa-v1
@FAALoginNewCredentials
Scenario: RV1_CDAA_01 - creating draft application and deleting it in FAA
Given the apprenticeship vacancy is Live in Recruit with no application
When draft application is created in FAA
Then Candidate is able to delete draft application

