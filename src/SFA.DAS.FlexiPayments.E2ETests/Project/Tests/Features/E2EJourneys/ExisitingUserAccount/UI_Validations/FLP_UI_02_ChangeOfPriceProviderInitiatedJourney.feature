Feature: FLP_UI_02_ChangeOfPriceProviderInitiatedJourney

The purpose of this test is to validate the UI journey (input fields + validation errors) for a training provider while 
raise a Change of Price request for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_02 Change Of Price Provider Initiated Journey
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 15000        | true         |
    And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider submits change of price form without changing input fields
	Then all default change of price validation errors are displayed to the Provider
	And validate Training Price and EPA price must be between 1 and 100000
	And a dynamic Total price field is displayed with the sum of Training price and End-point assessment price
	And validate Effective From Date cannot be before Training Start Date
	And validate Effective From Date cannot be after Training End Date
    And Provider creates a Change of Price request where Training Price is increased by 500
	And Provider is able to view details of change of price request
	And Provider can successfully cancel the change of price request
	# create another request below that employer can view and reject
	And Provider proceeds to create a Change of Price request for flexi payments pilot learner
	And Provider creates a Change of Price request where Training Price is increased by 500
	And Employer searches for learner on Manage your apprentices page
	And Employer is able to view the pending Change of Price request
	And Employer can view the details of the Change of Price request 
	And Employer is able to successfully reject the Change of Price request
	And Provider is notified that the Employer has rejected a price change through email