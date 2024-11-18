Feature: FLP_UI_04_ChangeOfStartDateJourney

The purpose of this test is to validate the UI journey (input fields + validation errors) for 
Change of Start Date initiated by Training Provider. The employer used in this test will be a non-levy employer.

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_04_01 Change Of Start Date Journey
	Given NonLevy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2000/11/20    | StartPreviousMonth | 12                 | 18000        | true         |
	And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Start Date request for flexi payments pilot learner
	And Provider submits change of start date form without changing input fields
	Then all default change of start date validation errors are displayed to the Provider
	And validate Actual training start date cannot be before the Earliest start date for the standard
	And Provider successfully creates a Change of Start Date request
	And Provider is able to view details of change of Start Date request
	And Provider can successfully cancel the change of Start Date request
	And Provider proceeds to create a Change of Start Date request for flexi payments pilot learner
	And Provider successfully creates a Change of Start Date request
	And Employer searches for learner on Manage your apprentices page
	And Employer is able to view the pending Change of Start Date request
	And Employer can view the details of the Change of Start Date request
	And Employer is able to successfully reject the Change of Start Date request


@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_UI_04_02 Prevent Change Of Start Date after qualifying period
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str            | duration_in_months | agreed_price | pilot_status |
		| 1       | 91            | 2000/11/20    | QualifyingPeriodStartDate | 12                 | 18000        | true         |
	When Provider searches for the learner on Manage your apprentice page
	Then do not display an option to change the actual training start date
