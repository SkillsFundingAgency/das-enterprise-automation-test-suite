Feature: FLP_CoC_01_ManageChangeOfCircumstances

The purpose of this test is to validate Employer and Training providers are not able to access Change of Circumstances functionality 
for learners opted in the pilot. They should be able to make changes to aproved learns that are opted out of the pilot, though

@regression
@flexi-manage-coc
@flexi-payments
Scenario: FLP_E2E_EUA_01 Employer adds two apprentices details to a cohort and Provider opts them into the pilot
	Given the Employer logins using existing Levy Account
	And Employer adds apprentices to the cohort with the following details
		| ULN_Key | training_code | date_of_birth | start_date_str | duration_in_months | agreed_price |
		| 1       | 154           | 2004/06/20    | 2023/08/01     | 11                 | 15000        |
		| 2       | 91            | 2004/06/27    | 2022/09/01     | 11                 | 18000        |
	And the Employer approves the cohort
	And provider logs in to review the cohort
	And the provider adds Uln and Opt learner 1 into the pilot
	And the provider adds Uln and Opt learner 2 out of the pilot
	When Provider successfully approves the cohort
	Then Provider can search learner 1 using Simplified Payments Pilot filter set to yes on Manage your apprentices page