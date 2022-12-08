Feature: FLP_TR_01_TransfersApprovalJourney

@regression
@liveapprentice
@flexi-payments
Scenario: FLP_TR_01 Transfers - Creating Cohort and then approved by all 3 parties
	Given Receiver sends an approved cohort with 2 apprentices to the provider with the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/06/01    | 2023/08/01     | 12                 | 15000        |
		| 2       | 91            | 2004/06/01    | 2023/09/01     | 12                 | 18000        |
	When the provider adds Ulns and opts the learners out of the pilot
	And Provider successfully approves the cohort
	And Sender approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost |
		| 1       | false    | 2023/08/01                  | Null                      | 15000              |
		| 2       | false    | 2023/09/01                  | Null                      | 18000              |
	#And validate the following data in Earnings Apprenticeship database
	#	| ULN_Key | start_date_str | planned_end_date | agreed_price | funding_type | funding_band_maximum |
	#	| 1       | 2023/08/01     | 2024/07/01       | 15000        | 2            | 15000                |
	#	| 2       | 2023/09/01     | 2024/08/01       | 18000        | 2            | 18000                |