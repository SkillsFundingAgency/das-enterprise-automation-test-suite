Feature: RV1_CHAS_01

A short summary of the feature

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CVSD_01 - Change Application status 
Then Provider is able to change the status of the Application '<FromStatus>' to '<ToStatus1>' to '<ToStatus2>'


Examples:
	| FromStatus | ToStatus1    | ToStatus2    |
	| New        | In Progress  | New          |
	| New        | In Progress  | Successful   |
	| New        | In Progress  | UnSuccessful |
	| New        | Successful   | New          |
	| New        | Successful   | In Progress  |
	| New        | Successful   | UnSuccessful |
	| New        | UnSuccessful | New          |
	| New        | UnSuccessful | In Progress  |
	| New        | UnSuccessful | Successful   |