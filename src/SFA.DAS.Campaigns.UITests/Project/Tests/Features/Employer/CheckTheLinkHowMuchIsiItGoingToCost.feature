Feature: EmployerLinkHOwMuchIsItGoingToCost
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@campaign
@regression
Scenario: Check the links How Much Is It Going To Cost?
		Given I navigate to Fire It Up home page
		And I click on th Employer option in the Menu header
		And I launch the How Much Is It Going To Cost? page
		Then I verify the Title of How Much Is It Going To Cost? the page
		

	