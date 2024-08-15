Feature: FLP_UI_05_ProviderPaymentStatus

A short summary of the feature

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_05 Provider payment status journey
	Given NonLevy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2005/11/20    | StartPreviousMonth | 24                 | 15000        | true         |
	When Provider searches for the learner on Manage your apprentice page
	Then display a Provider payments status row with Active status to Provider
	And Employer searches for learner on Manage your apprentices page
	And display a Provider payments status row with Active status to Employer
	And employer is able to successfully freeze provider payments
	And display a Provider payments status row with Inactive status to Employer
	And provider payment status is successfully updated to Inactive in apprenticeships db
	And employer is able to successfully unfreeze provider payments
	And display a Provider payments status row with Active status to Employer
	And provider payment status is successfully updated to Active in apprenticeships db