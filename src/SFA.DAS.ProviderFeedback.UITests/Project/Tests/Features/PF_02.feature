Feature: PF_02

@providerfeedback
@regression
Scenario: PF_02 User Submit Mandatory Information
	Given the user on the homepage
	When the user skips the question and selects a rating
	Then the user can submit a complaint