Feature: FLP_E2E_EUA_04_ExistingUserAccount

@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_04 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer logins using existing Levy Account
	And Pilot Provider adds apprentices to the cohort witht the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/06/01    | Today          | 12                 | 15000        |
		| 2       | 91            | 2004/06/01    | Today          | 12                 | 18000        |
	When pilot provider approves the cohort
	And employer reviews and approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost | training_price | endpoint_assessment_price |
		| 1       | true     | Today                       | Null                      | 15000              | 12000          | 3000                      |
		| 2       | true     | Today                       | Null                      | 18000              | 14400          | 3600                      |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | funding_platform | start_date_str | planned_end_date_str | agreed_price | funding_type | funding_band_maximum |
		| 1       | 1                | Today          | +12Months            | 15000        | 0            | 15000                |
		| 2       | 1                | Today          | +12Months            | 18000        | 0            | 18000                |
	And validate the following data is created in the earnings database
		| ULN_Key | total_on_program_payment | monthly_on_program_payment | number_of_delivery_months |
		| 1       | 12000                    | 1000                       | 12                        |
		| 2       | 14400                    | 1200                       | 12                        |