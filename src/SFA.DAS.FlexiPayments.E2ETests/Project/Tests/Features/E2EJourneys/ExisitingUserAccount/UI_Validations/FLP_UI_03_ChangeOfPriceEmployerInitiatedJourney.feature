Feature: FLP_UI_03_ChangeOfPriceEmployerInitiatedJourney

The purpose of this test is to validate the UI journey (input fields + validation errors) for Employer while 
raise a Change of Price request for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_03 Change Of Price Employer Initiated Journey
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | Today          | 12                 | 15000        | true         |
	And Employer searches for the learner on Manage your apprentice page
	When Employer proceeds to create a Change of Price request for flexi payments pilot learner
	And Employer submits change of price form without changing input fields
	Then all default validation errors are displayed to the Employer
	And validate new Total Price must be between 1 and 100000
	And a read-only current Total Price is displayed on the page
	And validate Employer cannot enter an Effective From Date that is before Training Start Date
	And validate Employer cannot enter an Effective From Date that is after Training End Date
	And Employer successfully creates a Change of Price request
	And Employer is able to view details of change of price request
	And Employer can successfully cancel the change of price request
	# create another request below that provider can view and reject
	And Employer proceeds to create a Change of Price request for flexi payments pilot learner
	And Employer successfully creates a Change of Price request
	And Provider searches for the learner on Manage your apprentice page
	And Provider is able to view the pending Change of Price request
	And Provider can view the details of the Change of Price request
	And Provider is able to successfully reject the Change of Price request
