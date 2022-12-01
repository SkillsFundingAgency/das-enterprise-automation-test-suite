Feature: FLP_E2E_EUA_03_ExistingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_NL_01 Non Levy Employer sends an approved cohort to the provider who opts first learner in the pilot and second out of the pilot
	Given the Employer logins using existing NonLevy Account
	And the Employer uses the reservation to create and approve apprentices with the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 131           | 2004/05/01    | Today          | 24                 | 6000         |
		| 2       | 131           | 2004/05/01    | Today          | 24                 | 6000         |
	And the Employer approves the cohort
	And provider logs in to review the cohort
	And the provider adds Uln and Opt learner 1 into the pilot
	And the provider adds Uln and Opt learner 2 out of the pilot
	When Provider successfully approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost |
		| 1       | true     | Today                       | Null                      | 6000               |
		| 2       | false    | Today                       | Null                      | 6000               |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | start_date_str | planned_end_date | agreed_price | funding_type | funding_band_maximum |
		| 1       | Today          | 2025/07/01       | 6000         | 1            | 6000                 |
		| 2       | Today          | 2024/12/01       | 6000         | 1            | 6000                 |
	#And validate the following data is created in the earnings database
	#	| ULN_Key | total_on_program_payment | monthly_on_program_payment | number_of_delivery_months |
	#	| 1       | 14400                    | 600                        | 24                        |