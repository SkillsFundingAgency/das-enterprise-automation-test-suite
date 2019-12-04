Feature: RV1_CHAS

@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_CVSD_02 - Change In Progress Application status
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to change the status of the In progress application to '<ToStatus>'

	Examples:
		| ToStatus     |
		| New          |
		| Successful   |
		| Unsuccessful |