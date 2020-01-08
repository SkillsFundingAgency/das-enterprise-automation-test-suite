Feature: CheckTheLinkChoosingATrainingProvider
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@regression
Scenario: Check all the link The Right Apprenticeship
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I launch Choosing A Training Provider page
	Then I verify the title for Choosing A Training Provider page
