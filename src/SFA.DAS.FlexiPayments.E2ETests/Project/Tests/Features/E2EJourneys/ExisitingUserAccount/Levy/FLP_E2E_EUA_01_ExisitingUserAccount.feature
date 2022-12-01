Feature: FLP_E2E_EUA_01_ExisitingUserAccount

Note that, in the tables below, ULN column is used as a key to store and retrieve ULNs that are used while creating 
commitments through the UI. These are later used to validate data in the commitments and earnings db. 

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_01 Employer adds two apprentices details to a cohort and Provider opts them into the pilot
	Given the Employer logins using existing Levy Account
	And Employer adds apprentices to the cohort with the following details
		| ULN_Key | training_code | date_of_birth | actual_start_date | planned_end_date | agreed_price |
		| 1       | 154           | 2004/05/27    | 2023/08/01        | 2024/07/31       | 15000        |
		| 2       | 91            | 2004/05/27    | 2023/09/01        | 2024/08/31       | 18000        |
	And the Employer approves the cohort
	And the provider adds Ulns and Opt the learners into the pilot
	When Provider successfully approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date | price_episode_to_date | price_episode_cost |
		| 1       | true     | 2023/08/01              | Null                  | 15000              |
		| 2       | true     | 2023/09/01              | Null                  | 18000              |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | actual_start_date | planned_end_date | agreed_price | funding_type | funding_band_maximum |
		| 1       | 2023/08/01        | 2024/07/01       | 15000        | 1            | 15000                |
		| 2       | 2023/09/01        | 2024/08/01       | 18000        | 1            | 18000                |
	#And validate the following data is created in the earnings database
	#	| ULN_Key | total_on_program_payment | monthly_on_program_payment | number_of_delivery_months |
	#	| 1       | 12000                    | 1000                       | 12                        |
	#	| 2       | 14400                    | 1200                       | 12                        |