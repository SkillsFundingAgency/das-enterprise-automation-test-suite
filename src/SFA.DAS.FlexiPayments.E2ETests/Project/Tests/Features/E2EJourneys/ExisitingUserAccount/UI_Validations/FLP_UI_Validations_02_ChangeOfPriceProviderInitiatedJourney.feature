Feature: FLP_UI_Validations_02_ChangeOfPriceProviderInitiatedJourney

The purpose of this test is to validate the UI journey (input fields + validation errors) for a training provider to 
successully raise a Change of Price request for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_Validations_02 Change Of Price Provider Initiated Journey
	Given fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 15000        | true         |
    And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider submits change of price form without changing input fields
	Then all default validation errors are displayed to the Provider
	And validate Training Price and EPA price must be between 1 and 100000
	And validate Effective From Date cannot be before Training Start Date
	And validate Effective From Date cannot be after Training End Date