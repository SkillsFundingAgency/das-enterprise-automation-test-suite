Feature: Example4

As a user
I want to be able to navigate to DFE home page
So that I can see all department services and information 

	@regression
	Scenario: User navigate to VAT home page from GOV.UK page
		Given I navigate to GOV.UK home page
		When I search for VAT
		When I click on VAT link
		Then I should be on DFE home page
