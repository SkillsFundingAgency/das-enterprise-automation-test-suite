Feature: FLP_UI_Validations_01_TrainingPriceAndEPAPriceAreReset

The purpose of this test is to perform UI validations in the below workflow:
- Training Provider adds a learner's details and send them to the employer 
- Employer reviews the details and suggests a different Total price; sends back the details to TP for approval
- When TP review the details, Total price suggested by Employer is displayed but Training Price and EPA price are reset 
- TP is unable to approve the cohort until they enter Training Price and EPA price

@regression
@e2escenarios
@flexi-payments
Scenario: [FLP_UI_Validations_01_TrainingPriceAndEPAPriceAreResetWhenEmployerChangesToANewTotalPRice
	Given the Employer logins using existing Levy Account
	And Pilot Provider adds apprentices to the cohort witht the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/06/01    | 2023/08/15     | 12                 | 15000        |
	And pilot provider approves the cohort
	And Employer changes the Total Price then approve the cohort and sends it to the training provider
	When provider logs in to review the cohort
	Then validate Training Price and EPA price have been reset with blue warning message displayed
	And verify training provider cannot approve the cohort 
