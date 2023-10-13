@accessibility
@approvals
Feature: AP_E2E_ACC_Accessibility04
Navigation journey through EAS and PAS 

@provideraddapprentice 
@nonlevyproviderscenarios
Scenario:  AP_E2E_ACC_04_1 Provider makes reservation adds edits and deletes apprentice for non-levy employer
	Given An Employer has given create reservation permission to a provider
	Then Provider can make a reservation
	And Provider can add an apprentice
	And Provider can edit an apprentice
	And Provider can delete an apprentice

@provideraddapprentice
Scenario:  AP_E2E_ACC_04_2 Provider Selects Filter And Pagination
	Given A Provider has navigated to Manage your apprentice page
	When the provider filters by 'Live'
	Then the provider is presented with first page with no filters applied

	@provideraddapprentice
Scenario: AP_E2E_ACC_04_3 Provider adds apprentices and views cohort details when the cohort is with the employer
	Given the Employer logins using existing Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices approves them and sends to employer to approve
	Then Provider is able to view the cohort with employer
	And Provider is able to view all apprentice details when the cohort with employer

	@limitingstandards
Scenario: AP_E2E_ACC_04_04_Limiting Standards In Edit Cohort
Given provider does not offer Standard-X
And provider receives a apprentice request that contains Standard-X
When provider opens apprentice requests
Then provider see warning messages in approve apprentice page