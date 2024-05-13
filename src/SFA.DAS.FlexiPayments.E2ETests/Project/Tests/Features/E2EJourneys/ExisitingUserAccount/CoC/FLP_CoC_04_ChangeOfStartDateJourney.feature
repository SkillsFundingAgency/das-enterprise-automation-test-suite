Feature: FLP_CoC_04_ChangeOfStartDateJourney

The purpose of the below testa is to successfully raise a Change of Start Date request initiated by a training provider 
for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_04 Change Of Start Date Journey - Happy Path
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 18000        | true         |
    And Provider searches for the learner on Manage your apprentice page
	When Provider proceeds to create a Change of Start Date request for flexi payments pilot learner
	And Provider successfully creates a Change of Start Date request
	And Change of Start Date request details are saved in the PriceHistory table
	Then Employer can review the Change of Start Date request and approve it
	And the approved Change of Start Date request is saved in the PriceHistory table