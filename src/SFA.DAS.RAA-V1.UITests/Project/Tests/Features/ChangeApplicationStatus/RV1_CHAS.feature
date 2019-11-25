Feature: RV1_CHAS

A short summary of the feature

@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_CVSD_01 - Change New Application status 
Then Provider is able to change the status of the new application to '<ToStatus>'

Examples:
	| ToStatus     |
	| In progress  |
	| Successful   |
	| Unsuccessful |


@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_CVSD_02 - Change In Progress Application status 
Then Provider is able to change the status of the In progress application to '<ToStatus>'

Examples:
	| ToStatus     |
	| New          |
	| Successful   |
	| Unsuccessful |