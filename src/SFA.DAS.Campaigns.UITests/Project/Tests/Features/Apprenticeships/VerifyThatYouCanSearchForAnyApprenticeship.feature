Feature: VerifyThatYouCanSearchForAnyApprenticeship
	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

	@regression
	Scenario: User can find an apprentice from Apprenticeships home page
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		And I Click on Find An Apprenticeship option in the Menu Bar Header
		When I select a valid Care services
		And I enter a valid CV1 1DD
		And I select miles 40 miles
		And I click on Serach button
		Then I click on first search result
		And I can verify Apprentice Details Of Results Page Against Apprentice Details of Summary page