Feature: RV1_FAACDA_01

@raa-v1
@faa
@regression
@apprenticeshipvacancy
@FAALoginNewCredentials
Scenario: RV1_FAACDA_01 - creating draft application and deleting it in FAA
	Given the Applicant creates a new FAA account
	And the apprenticeship vacancy is Live in Recruit with no application
	When draft application is created in FAA
	Then Candidate is able to delete draft application