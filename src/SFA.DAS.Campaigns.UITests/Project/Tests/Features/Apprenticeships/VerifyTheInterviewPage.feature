Feature: VerifyTheInterviewPage
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@campaigns
@regression
Scenario: Check all the links and content of INTERVIEW screen
	Given I navigate to Fire It Up home page
	And I launch the Find An Apprentice page
	And I Focus on the link How Do They Work link
	And I launch the Interview page
	Then I verify the content under The Interview Process section
	And I verify the content under Before Your Interview section