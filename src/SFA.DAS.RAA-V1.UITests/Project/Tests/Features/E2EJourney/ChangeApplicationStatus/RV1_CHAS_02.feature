Feature: RV1_CHAS_02


@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CHAS_02 - Change In Progress Application status to Successful 
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to change the status of the In progress application to 'Successful'
	And the candidate is able to dismiss the Notifications in FAA 'Successful'