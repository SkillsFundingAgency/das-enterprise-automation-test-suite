Feature: AED_E_02_EmployerSharesInterestOfANumberOfApprentices

@aggregatedemployerdemand
@regression
@testinator
Scenario: AED_E_02_EmployerSharesInterestOfANumberOfApprentices
	Given the User searches a course then navigates to the provider list
	And the user selects get help with finding a training provider
	Then the user can register interest with apprentices
