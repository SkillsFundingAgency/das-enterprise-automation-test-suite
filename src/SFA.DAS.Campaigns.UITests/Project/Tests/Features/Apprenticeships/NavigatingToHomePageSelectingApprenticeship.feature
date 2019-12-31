Feature: NavigatingToHomePageSelectingApprenticeship

	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@regression
Scenario: User can find an apprentice from Apprenticeships home page
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		And I Focus on the link Are Apprenticeship Right For You
		And I launch the Real Stories page
		Then I verify the content under Real Stories header
		And I can play the first video on the screen