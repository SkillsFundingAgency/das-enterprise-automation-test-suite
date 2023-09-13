Feature: FLP_E2E_NL_01_ExistingUserAccount

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
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost | training_price | endpoint_assessment_price |
		| 1       | true     | Today                       | Null                      | 6000               | 4800           | 1200                      |
		| 2       | false    | StartCurrentMonth           | Null                      | 6000               | Null           | Null                      |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | funding_platform | actual_start_date_str | start_date_str    | planned_end_date_str | agreed_price | funding_type | funding_band_maximum |
		| 1       | 1                | Today                 | StartCurrentMonth | +24Months            | 6000         | 1            | 18000                |
		| 2       | 2                | Null                  | StartCurrentMonth | +24Months            | 6000         | 1            | 18000                |
	And validate the following data is created in the earnings database
		| ULN_Key | total_on_program_payment | monthly_on_program_payment | number_of_delivery_months |
		| 1       | 4800                     | 200                        | 24                        |
	And validate earnings are not generated for the learners
		| ULN_Key |
		| 2       |