@approvals
Feature: AP_CoC_08

@regression
@cocscenarios
@mytag
Scenario: AP_CoC_08 Provider Edits Apprentice Dob And Reference And Employer approves it
	Given the Employer has approved apprentice
	When the provider edits Name Dob and Reference
	And the employer accepts these changes
	Then the changes should be displayed on the view apprentice page
