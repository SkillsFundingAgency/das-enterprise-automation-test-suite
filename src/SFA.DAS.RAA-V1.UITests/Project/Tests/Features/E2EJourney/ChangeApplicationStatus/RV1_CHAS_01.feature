Feature: RV1_CHAS_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CHAS_01 - Change In Progress Application status to New 
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to change the status of the In progress application to 'New'

