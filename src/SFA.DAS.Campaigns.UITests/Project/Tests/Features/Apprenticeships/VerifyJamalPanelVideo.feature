Feature: VerifyJamalPanelVideo
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@campaign
@regression
Scenario: User verifies Jamal Panel
	Given I navigate to Fire It Up home page
	And I launch the Jamal page
	Then I verify the content on jamal Panel
	And I can play the first video on the screen