Feature: Feature1

A short summary of the feature

Scenario: Create An Employer Account Scenario 2
	Given I navigate to the Create Account page
	When I submit the form with the mandatory data items supplied
	And I submit the activation code recieved as a consequence of a successful form submission
	Then a DAS account will be created
