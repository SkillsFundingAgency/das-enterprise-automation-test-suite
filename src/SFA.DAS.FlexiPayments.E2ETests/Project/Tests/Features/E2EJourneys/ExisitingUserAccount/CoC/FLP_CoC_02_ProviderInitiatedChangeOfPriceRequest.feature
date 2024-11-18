Feature: FLP_CoC_02_ProviderInitiatedChangeOfPriceRequest

The purpose of the below testa is to successfully raise a Change of Price request initiated by a training provider 
for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_02_1 Provider Initiated Change Of Price Request - Total Price Increased
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | Today          | 12                 | 14500        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider creates a Change of Price request where Training Price is increased by 500
	And Provider initiated Change of Price request details are saved in the PriceHistory table
	And Employer is notified that a provider has requested a price change through email 
	Then Employer can review the Change of Price request and approve it
	And the approved Change of Price request is saved in the PriceHistory table
	And validate earnings instalments are updated to reflect the new agreed price of 15000

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_02_2 Provider Initiated Change Of Price Request - Auto-Approve - Total Price Decreased
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 15000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider creates a Change of Price request where Training Price for the apprenticeship is reduced by 500
	Then the approved Change of Price request is saved in the PriceHistory table

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_02_3 Provider Initiated Change Of Price Request - Auto-Approve - Total Price remains the same
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 18000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider creates a Change of Price request where Total price remains the same
	Then the approved Change of Price request is saved in the PriceHistory table