Feature: VerifyWhatIsAnApprenticeship
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

@campaigns
@regression
Scenario: User can find an apprentice from Apprenticeships home page
	Given I navigate to Fire It Up home page
	And I launch the Find An Apprentice page
	And I Focus on the link How Do They Work link
	And I launch the What Is An Apprenticeship page
	Then I verify the content under WHAT IS AN APPRENTICESHIP section
	And I verify the content under WHAT ARE THE DIFFERENT TYPES OF APPRENTICESHIPS section