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