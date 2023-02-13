Feature: FLP_E2E_EUA_04_ExistingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_04 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer logins using existing Levy Account
	And Pilot Provider adds apprentices to the cohort witht the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/06/01    | 2023/08/01     | 11                 | 15000        |
		| 2       | 91            | 2004/06/01    | 2023/09/01     | 11                 | 18000        |
	When pilot provider approves the cohort
	And employer reviews and approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost |
		| 1       | true     | 2023/08/01                  | Null                      | 15000              |
		| 2       | true     | 2023/09/01                  | Null                      | 18000              |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | funding_platform | actual_start_date_str | start_date_str | planned_end_date_str | agreed_price | funding_type | funding_band_maximum |
		| 1       | 1                | 2023/08/01            | 2023/08/01     | 2024/07/01           | 15000        | 0            | 15000                |
		| 2       | 1                | 2023/09/01            | 2023/08/01     | 2024/08/01           | 18000        | 0            | 18000                |
	And validate the following data is created in the earnings database
		| ULN_Key | total_on_program_payment | monthly_on_program_payment | number_of_delivery_months |
		| 1       | 12000                    | 1000                       | 12                        |
		| 2       | 14400                    | 1200                       | 12                        |