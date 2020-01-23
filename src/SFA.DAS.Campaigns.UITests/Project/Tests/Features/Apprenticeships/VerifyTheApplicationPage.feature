Feature: VerifyTheApplicationPage
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@campaigns
@regression
Scenario: Check all the links and content of APPLICATION screen
	Given I navigate to Fire It Up home page
	And I launch the Find An Apprentice page
	And I Focus on the link How Do They Work link
	And I launch the Application page
	Then I verify the content under SO, YOU'VE FOUND THE APPRENTICESHIP section
	And I verify the content under APPLY FOR THE JOB section
	And I verify the content under WAIT FOR THE APPLICATIONS section
	And I verify the content under IF YOU’RE ON THE SHORTLIST section
	And I verify the content under TRAINING PROVIDERS section
