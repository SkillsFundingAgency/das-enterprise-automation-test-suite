Feature: ApprenticeFeature 

	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

	
	Scenario Outline: User can find an apprentice from Apprenticeships home page
		Given I navigate to Fire It Up home page
		When I launch the Find An Apprentice page
		Then I select a valid <SelectInterest>
		Then I enter a valid <Postcode>
		Then I select miles <NoOfMiles>
		Then I click on Serach button
		When I click on first search result

		Examples: 
		| SelectInterest                | Postcode | NoOfMiles |
		| Engineering and manufacturing | CV11DD   | 40 miles  |


