Feature: FLP_Access_01_PerformAccessibilityTesting

@accessibility
@regression
@flexi-payments
Scenario: FLP_Access_01 Perform Accessibility Testing on Flexi-payment screens
	Given fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | pilot_status |
		| 1       | 154           | 2004/06/20    | 2023/08/01     | 12                 | 15000        | true         |
		| 2       | 91            | 2004/06/27    | 2022/09/01     | 12                 | 18000        | false        |
	When Provider can search learner 1 using Simplified Payments Pilot filter set to yes on Manage your apprentices page
	Then Provider cannot make changes to fully approved learner 1
	When Provider can search learner 2 using Simplified Payments Pilot filter set to no on Manage your apprentices page
	Then Provider can make changes to fully approved learner 2
	When Employer searches learner 1 on Manage your apprentices page
	Then Employer cannot make changes to fully approved learner 1
	When Employer searches learner 2 on Manage your apprentices page
	Then Employer can make changes to fully approved learner 2
	When provider is on Apprenticeship indicative earnings report page 
	Then validate correct earnings numbers are displayed