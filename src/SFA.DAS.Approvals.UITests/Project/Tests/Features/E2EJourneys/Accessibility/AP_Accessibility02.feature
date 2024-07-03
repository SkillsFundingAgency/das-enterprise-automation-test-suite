@accessibility
@approvals
Feature: AP_E2E_ACC_Accessibility02
Navigation journey through EAS and PAS 

@addlevyfunds
@e2escenarios
Scenario: AP_E2E_ACC_02_1 Create Employer send an approved cohort then provider approves the cohort
Given The User creates LevyEmployer account and sign an agreement
	When the Employer adds 2 apprentices and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then Provider is able to view the cohort with employer
	And Provider is able to view all apprentice details when the cohort with employer
	Then the Employer approves the cohorts


Scenario:  AP_E2E_ACC_02_2 Employer searches for apprentices
	Given An employer has navigated to Manage your apprentice page
	When the employer filters by 'Live'
	Then the employer is presented with first page with filters applied


	Scenario:  AP_E2E_ACC_02_3 Employer requests change to dob and reference After ILR match and Provider approves
	Given the Employer has approved apprentice
	When the Employer edits Dob and Reference and confirm the changes after ILR match
	Then the provider can review and approve the changes