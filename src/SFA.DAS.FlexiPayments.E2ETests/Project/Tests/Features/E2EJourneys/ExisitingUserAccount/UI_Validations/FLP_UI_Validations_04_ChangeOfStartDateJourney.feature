Feature: FLP_UI_Validations_04_ChangeOfStartDateJourney

The purpose of this test is to validate the UI journey (input fields + validation errors) for 
Change of Start Date initiated by Training Provider. The employer used in this test will be a non-levy employer.

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_Validations_04 Change Of Start Date Journey
	Given NonLevy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2000/11/20    | StartPreviousMonth | 24                 | 18000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Start Date request for flexi payments pilot learner
	And Provider submits change of start date form without changing input fields
	Then all default change of start date validation errors are displayed to the Provider
	And Provider successfully creates a Change of Start Date request
	And Provider is able to view details of change of Start Date request
	And Employer searches for learner on Manage your apprentices page
	And Employer is able to view the pending Change of Start Date request
	And Employer can view the details of the Change of Start Date request 