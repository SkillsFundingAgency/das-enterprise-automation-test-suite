Feature: FLP_E2E_EUA_01_ExisitingUserAccount

Note that, in the tables below, ULN column is used as a key to store and retrieve ULNs that are used while creating 
commitments through the UI. These are later used to validate data in the commitments and earnings db. 
Please do not change the ULN keys and any new entries in the table will need to follow the same structure: "ULN<n>"

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_01 Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing Levy Account
	And Employer adds apprentices to the cohort with the following details
		| ULN  | training_code | date_of_birth | actual_start_date | planned_end_date | agreed_price |
		| ULN1 | 154           | 2004/05/27    | 2023/08/01        | 2024/07/31       | 15000        |
		| ULN2 | 91            | 2004/05/27    | 2023/09/01        | 2024/07/31       | 18000        |
	And the Employer approves the cohort
	And the provider adds Ulns and Opt the learners into the pilot
	When Provider successfully approves the cohort
	Then validate the following data is created in the commitments database
		| ULN  | is_pilot | price_episode_from_date | price_episode_cost |
		| ULN1 | true     | 2023/08/01              | 15000              |
		| ULN2 | true     | 2023/09/01              | 18000              |