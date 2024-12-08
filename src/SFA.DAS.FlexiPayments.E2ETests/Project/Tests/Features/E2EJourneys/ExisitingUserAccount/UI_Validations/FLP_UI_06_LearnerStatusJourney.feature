Feature: FLP_UI_06_LearnerStatusJourney

A short summary of the feature

@regression
@flexi-payments
Scenario: FLP_UI_06 Learner Status journey - In Learning
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2005/11/20    | StartPreviousMonth | 24                 | 15000        | true         |
	When Provider searches for the learner on Manage your apprentice page
	Then Provider can see a Learner Status row with InLearning status for the Apprentice
	And Employer searches for learner on Manage your apprentices page
	And Employer can see a Learner Status row with InLearning status for the Apprentice


@regression
@flexi-payments
Scenario: FLP_UI_06 Learner Status journey - Waiting To Start
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2005/11/20    | StartNextMonth | 24                 | 15000        | true         |
	When Provider searches for the learner on Manage your apprentice page
	Then Provider can see a Learner Status row with WaitingToStart status for the Apprentice
	And Employer searches for learner on Manage your apprentices page
	And Employer can see a Learner Status row with WaitingToStart status for the Apprentice
