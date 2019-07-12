Feature: Example feature
	As a user
	I want to be able to navigate to DFE home page
	So that I can see all department services and information 

	
	Scenario Outline: User navigate to DFE home page from GOV.UK page
		Given I navigate to GOV.UK home page
		When I search for <SearchLink>
		And I click on <SearchLink> link
		Then I should be on DFE home page

		Examples: 
		| SearchLink               |
		| Ministry of Defence      |
		| Department for Education |
		| Universal Credit         |
		| Corporation Tax          |

