@approvals
Feature: AP_COP_05_ChangeOfProvider_WithStopJourney

@regression
@changeOfProvider
@liveapprentice
Scenario: AP_COP_05_ChangeOfProvider_WithStopJourney
	Given the Employer has Live apprentice
	Then employer can start CoP Process
	And stop apprentice record during CoP journey