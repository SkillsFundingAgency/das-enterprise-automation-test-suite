Feature: Example3
	As a user
	I want to be able to navigate to DFE home page
	So that I can see all department services and information 

	
	Scenario: User navigate to Benifits Calculator home page from GOV.UK page
		Given I navigate to GOV.UK home page
		When I search for Benefits calculators
		And I click the same link
		Then I should be on DFE home page
