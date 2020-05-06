@approvals
Feature: AP_Pro_03_ProviderAddsReservationAddEditDeleteApprentice
	As a valid provider user 
	I want to be able to get funding for a non-levy employer
	So that provider can book courses for a certain training period

@regression 
@nonlevyproviderscenarios
@selectstandardcourse
Scenario: AP_Pro_03 Provider makes reservation adds edits and deletes apprentice for non-levy employer
	Given An Employer has given create reservation permission to a provider
	Then Provider can make a reservation
	And Provider can add an apprentice
	And Provider can edit an apprentice
	And Provider can delete an apprentice