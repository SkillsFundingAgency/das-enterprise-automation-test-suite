Feature: CheckTheLinkTheRightApprenticeship
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@campaigns
@regression
Scenario: Check That Find The Right Apprenticeship Search Works
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I launch The Right Apprenticeship page
	Then I verify the title for The Right Apprenticeship  page

