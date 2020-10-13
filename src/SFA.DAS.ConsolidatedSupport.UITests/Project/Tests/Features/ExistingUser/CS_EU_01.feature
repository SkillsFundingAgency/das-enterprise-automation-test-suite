Feature: CS_EU_01

@regression
@consolidatedsupport
Scenario: CS_EU_01_Existing User Ticket is resolved
	#Given an existing user emails the helpdesk
	Then a New status ticket is displayed
	When the ticket is submit as open
	Then a Open status ticket is displayed
