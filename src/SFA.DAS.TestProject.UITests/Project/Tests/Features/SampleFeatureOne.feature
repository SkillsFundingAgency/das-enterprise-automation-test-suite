Feature: SampleFeatureOne
	As a user
	I want to be able to navigate to DFE home page
	So that I can see all department services and information 

Scenario Outline: User navigates to DFE home page from GOV.UK page
	Given the User navigates to GOV.UK home page
	When the User searches for <SearchLink>
	And  clicks the same link
	Then the User should be on DFE home page

	Examples:
		| SearchLink               |
		| Ministry of Defence      |
		| Department for Education |
		| Universal Credit         |
		| Corporation Tax          |