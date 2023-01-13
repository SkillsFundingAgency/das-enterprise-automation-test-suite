Feature: FLP_E2E_EUA_02_ExisitingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_02 Employer adds two apprentices details to a cohort and Provider opts them out of the pilot
	Given the Employer logins using existing Levy Account
	And Employer adds apprentices to the cohort with the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/02/01    | 2023/08/01     | 11                 | 15000        |
		| 2       | 91            | 2004/02/01    | 2023/09/01     | 11                 | 18000        |
	And the Employer approves the cohort
	And the provider adds Ulns and opts the learners out of the pilot
	When Provider successfully approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost |
		| 1       | false    | 2023/08/01                  | Null                      | 15000              |
		| 2       | false    | 2023/09/01                  | Null                      | 18000              |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | is_pilot | actual_start_date_str | start_date_str | planned_end_date_str | agreed_price | funding_type | funding_band_maximum |
		| 1       | false    | Null                  | 2023/08/01     | 2024/07/01           | 15000        | 0            | 15000                |
		| 2       | false    | Null                  | 2023/09/01     | 2024/08/01           | 18000        | 0            | 18000                |
	And validate earnings are not generated for the learners
		| ULN_Key |
		| 1       |
		| 2       |