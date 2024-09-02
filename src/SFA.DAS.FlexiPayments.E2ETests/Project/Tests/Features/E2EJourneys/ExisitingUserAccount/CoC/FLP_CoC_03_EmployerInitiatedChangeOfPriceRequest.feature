Feature: FLP_CoC_03_EmployerInitiatedChangeOfPriceRequest

The purpose of this test is to successfully raise a Change of Price request initiated by Employer
for a learner opted in the pilot. 

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_03 Employer Initiated Change Of Price Request
	Given Levy Employer and Pilot provider have a fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str     | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | StartPreviousMonth | 12                 | 15000        | true         |
    And Employer searches for the learner on Manage your apprentice page
	When Employer proceeds to create a Change of Price request for flexi payments pilot learner
	And Employer successfully creates a Change of Price request to reduce the agreed price to 14500
	And Employer initiated Change of Price request details are saved in the PriceHistory table
	Then Provider can review the Change of Price request and approve it
	And the approved Change of Price request is saved in the PriceHistory table
	And validate instalments amounts have been updated in the earnings db to reflect the new agreed price of 14500
