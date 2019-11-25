@approvals
Feature: AP_NL_E2E_04_NonLevyE2EJourneyFour
	As a valid provider user 
	I want to be able to get funding for a non-levy EOI employer
	So that provider can book courses for a certain training period

@regression 
@nonlevyeoiproviderscenarios
Scenario: AP_NL_E2E_04 Provider makes reservation adds edits and deletes apprentice for non-levy EOI employers		
	Given An Employer has given create reservation permission to a provider
	Then Provider can make a reservation
	And Provider can add an apprentice
	And Provider can edit an apprentice
	And Provider can delete an apprentice