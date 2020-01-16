Feature: VerifyTheYourApprenticeshipPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@campaigns
@regression
Scenario: Check all the links and content of YOUR APPRENTICESHIP screen
	Given I navigate to Fire It Up home page
	And I launch the Find An Apprentice page
	And I Focus on the link Getting Started link
	And I launch the Your Apprenticeship page
	Then I verify the content under What to bring, and other useful info section
	And I verify the content under Meet your new team section
	And I verify the content under What comes after my apprenticeship section