Feature: FLP_CoC_02_ProviderInitiatedChangeOfPriceRequest

The purpose of this test is to successfully raise a Change of Price request initiated by a training provider 
for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_02 Provider Initiated Change Of Price Request
	Given fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 15000        | true         |
    And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider successfully creates a Change of Price request
