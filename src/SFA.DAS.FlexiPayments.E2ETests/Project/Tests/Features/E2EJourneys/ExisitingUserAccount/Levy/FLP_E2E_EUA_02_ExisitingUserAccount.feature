Feature: FLP_E2E_EUA_02_ExisitingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_02 Employer adds apprentice details to a cohort and Provider opts the learner out of the pilot
	Given the Employer logins using existing Levy Account
	And Employer adds apprentices to the cohort with the following details
		| ULN_Key | training_code | date_of_birth | start_date_str    | duration_in_months | agreed_price |
		| 1       | 154           | 2004/02/01    | StartCurrentMonth | 11                 | 15000        |
	And the Employer approves the cohort
	And the provider adds Ulns and opts the learners out of the pilot
	And Simplified Payments Pilot tags and additional columns are NOT displayed on Approve apprentice details page
	When Provider successfully approves the cohort
	Then validate the following data is created in the commitments database
		| ULN_Key | is_pilot | price_episode_from_date_str | price_episode_to_date_str | price_episode_cost | training_price | endpoint_assessment_price |
		| 1       | false    | StartCurrentMonth           | Null                      | 15000              |                |                           |
	And validate the following data in Earnings Apprenticeship database
		| ULN_Key | funding_platform | start_date_str    | planned_end_date_str | agreed_price | funding_type | funding_band_maximum |
		| 1       | 2                | StartCurrentMonth | +11Months            | 15000        | 0            | 15000                |
	And validate earnings are not generated for the learners
		| ULN_Key |
		| 1       |