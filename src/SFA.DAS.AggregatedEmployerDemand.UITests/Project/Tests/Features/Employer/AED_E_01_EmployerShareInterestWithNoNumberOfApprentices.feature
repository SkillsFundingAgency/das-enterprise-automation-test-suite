Feature: AED_E_01_EmployerShareInterestWithNoNumberOfApprentices

@aggregatedemployerdemand
@regression
Scenario: AED_E_01_EmployerShareInterestWithNoNumberOfApprentices
	Given the User searches a course then navigates to the provider list
	And the user selects get help with finding a training provider
	Then the user can register interest without apprentices
