Feature: WithdrawalIsRecorded

A short summary of the feature

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_05 Withdrawal Is Recorded - Learner Opted Out of Beta
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 18000        | true         |
	When a withdrawal is recorded with reason as WithdrawFromBeta