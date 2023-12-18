Feature: FLP_CoC_02_ChangeOfPriceProviderInitiated

The purpose of this test is to validate that the Training Provider can successully raise a Change of Price. 
The Employer approves the request and the earnings are recalculated

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_02 Change of Price request is approved and earnings are calculated - Provider Initiated
	Given fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | 2024/08/01     | 12                 | 15000        | true         |
	And Provider can search learner 1 using Simplified Payments Pilot filter set to yes on Manage your apprentices page
	When Provider proceeds to create a Change of Price request for flexi payments pilot learner
