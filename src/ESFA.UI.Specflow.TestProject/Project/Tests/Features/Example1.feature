Feature: Example1
	As a user
	I want to be able to navigate to DFE home page
	So that I can see all department services and information 

	
	@regression
	Scenario Outline: User navigate to MoD home page from GOV.UK page
		Given I navigate to GOV.UK home page
		When I search for <SearchLink>
		And I click the same link
		Then I should be on DFE home page

		Examples: 
		| SearchLink               |
		| Ministry of Defence      |
		| Department for Education |
		| Income Tax               |
		| VAT                      |