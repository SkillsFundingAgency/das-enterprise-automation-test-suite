@accessibility
@approvals
Feature: AP_E2E_ACC_Accessibility
Navigation journey through EAS and PAS 
#
#@approvalsnavigation
#Scenario: AP_E2E_ACC_01_Navigate to EAS sub sites from Apprentice Page
#	Given the Employer logins using existing Levy Account
#	When the Employer navigates to 'Apprentice' Page
#	Then the employer can navigate to home page
#	Then the employer can navigate to finance page
#	And the employer can navigate to paye scheme page
#	And the employer can navigate to your team page
#	And the employer can navigate to your organisation and agreement page
#	And the employer can navigate to account settings page
#	And the employer can navigate to rename account settings page
#	And the employer can navigate to notification settings page
#
@addlevyfunds
@e2escenarios
Scenario: AP_E2E_ACC_02_1 Create Employer send an approved cohort then provider approves the cohort
Given The User creates LevyEmployer account and sign an agreement
	When the Employer approves 1 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts
	Then Provider is able to view the cohort with employer
	And Provider is able to view all apprentice details when the cohort with employer
	Then the Employer approves the cohorts
	When the Employer edits Dob and Reference and confirm the changes after ILR match
	Then the provider can review and approve the changes
#
#Scenario:  AP_E2E_ACC_02_2 Employer searches for apprentices
#	Given An employer has navigated to Manage your apprentice page
#	When the employer filters by 'Live'
#	Then the employer is presented with first page with filters applied
#
#@non-levy
#@reservefunds
#@reservation
#Scenario: AP_E2E_ACC_03 Non Levy Employer sends an approved cohort then provider approves the cohort
#	Given the Employer logins using existing NonLevy Account
#	When the Employer uses the reservation to create and approve 1 cohort and sends to provider
#	Then the provider adds Ulns and approves the cohorts
#
#
#@provideraddapprentice 
#@nonlevyproviderscenarios
#Scenario:  AP_E2E_ACC_04_1 Provider makes reservation adds edits and deletes apprentice for non-levy employer
#	Given An Employer has given create reservation permission to a provider
#	Then Provider can make a reservation
#	And Provider can add an apprentice
#	And Provider can edit an apprentice
#	And Provider can delete an apprentice
#
#@provideraddapprentice
#Scenario:  AP_E2E_ACC_04_2 Provider Selects Filter And Pagination
#	Given A Provider has navigated to Manage your apprentice page
#	When the provider filters by 'Live'
#	Then the provider is presented with first page with no filters applied
#
#@ignoreindemo
#@ignoreintest
#@ignoreintest2
#Scenario:  AP_E2E_ACC_05 PublicSectorReporting
#	Given the Employer logins using existing NonLevy Account
#	Then the employer can create a new report
#	And then employer can edit a submitted report