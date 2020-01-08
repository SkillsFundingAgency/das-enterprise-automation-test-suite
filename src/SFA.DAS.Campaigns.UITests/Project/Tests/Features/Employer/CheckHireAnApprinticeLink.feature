Feature: CheckHireAnApprinticeLink
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 
@regression
Scenario: Check the link Hire An Apprentice Link
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I launch Hire An Apprentice page
	Then I verify the title for Hire An Apprentice page
