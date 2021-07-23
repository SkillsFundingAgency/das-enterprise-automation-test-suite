Feature: CA_EMP_16

@campaigns
@apprentice
@regression
@ignore
Scenario: CA_EMP_16 Check Employer Guide Page
	Given the user navigates to Employer Guide Page
	Then the links are not broken
