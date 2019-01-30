Feature: Example8 feature
	As a user
	I want to be able to navigate to DFE home page
	So that I can see all department services and information 

	@regression
	Scenario: User8 navigate to DFE home page from GOV.UK page
		Given I navigate to GOV.UK home page and search for Department for Education
		When I click on DFE link
		Then I should be on DFE home page

