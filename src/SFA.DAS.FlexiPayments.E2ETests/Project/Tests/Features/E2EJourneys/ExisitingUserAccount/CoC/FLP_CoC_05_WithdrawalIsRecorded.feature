Feature: WithdrawalIsRecorded

A short summary of the feature

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_05_01 Withdrawal Is Recorded - Learner Opted Out of Beta
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 18000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When a withdrawal is recorded with reason as WithdrawFromBeta
	Then apprenticeship is marked as withdrawn
	And the approval of the apprenticeship is maintained but it is removed from private beta



@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_05_02 Withdrawal Is Recorded - WithdrawDuringLearning
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str              | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartFirstDayOfTwoMonthsAgo | 12                 | 18000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When a withdrawal is recorded with reason as WithdrawDuringLearning
	Then apprenticeship is marked as withdrawn
	And Provider searches for the learner on Manage your apprentice page
	Then display a permanent confirmation banner to advise the Provider that the learner has been Withdrawn
	And Employer searches for the learner on Manage your apprentice page
	Then display a permanent confirmation banner to advise the Employer that the learner has been Withdrawn