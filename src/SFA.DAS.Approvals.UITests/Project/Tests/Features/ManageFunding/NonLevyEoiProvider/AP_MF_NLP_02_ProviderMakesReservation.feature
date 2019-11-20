@approvals
Feature: AP_MF_NLP_02_ProviderMakesReservation
	As a valid provider user 
	I want to be able to get funding for a non-levy EOI employer
	So that provider can book courses for a certain training period

@regression 
@nonlevyeoiproviderscenarios
Scenario: AP_MF_NLP_02 Provider makes reservation adds and deletes apprentice for non-levy EOI employers		
	Given An Employer has given create reservation permission to a provider
	Then Provider can make a reservation
	And Provider can add an apprentice
	And Provider can edit an apprentice
	And Provider can delete an apprentice
	And Provider can delete the funding
