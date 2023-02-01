Feature: FLP_CoC_01_ManageChangeOfCircumstances

The purpose of this test is to validate Employer and Training providers are not able to access Change of Circumstances functionality 
for learners opted in the pilot. They should be able to make changes to aproved learns that are opted out of the pilot, though

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_CoC_01 Employer and Provider cannot edit an approved pilot learner but can edit a non-pilot user
	Given fully approved apprentices with the below data
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price | is_pilot |
		| 1       | 154           | 2004/06/20    | 2023/08/01     | 11                 | 15000        | true     |
		| 2       | 91            | 2004/06/27    | 2022/09/01     | 11                 | 18000        | false    |
	When Provider can search learner 1 using Simplified Payments Pilot filter set to yes on Manage your apprentices page
	Then Provider cannot make changes to fully approved learner 1
	When Provider can search learner 2 using Simplified Payments Pilot filter set to no on Manage your apprentices page
	Then Provider can make changes to fully approved learner 2