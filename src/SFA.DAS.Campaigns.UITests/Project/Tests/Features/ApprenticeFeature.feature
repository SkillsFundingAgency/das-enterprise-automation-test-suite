Feature: ApprenticeFeature 

	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

	Scenario: User can find an apprentice from Apprenticeships home page
		Given I navigate to Fire It Up home page
		When I launch the Find An Apprentice page
		Then I select a valid Engineering and manufacturing
		Then I enter a valid SW1V 3LP
		Then I select miles 40 miles
		Then I click on Serach button
		When I click on first search result
		Then I can see the Apprentice Summary page


	Scenario: User can see a valid message when no apprentice results found
		Given I navigate to Fire It Up home page
		When I launch the Find An Apprentice page
		Then I select a valid Engineering and manufacturing
		Then I enter a valid SW1V 3LP
		Then I select miles 5 miles
		Then I click on Serach button
		Then I can verify the content of no matching results page


	Scenario Outline: Application should show default value for Miles DropDown and valid error messages for invalid postcode and interest selection
		Given I navigate to Fire It Up home page
		When I launch the Find An Apprentice page
		Then I click on Serach button
		Then I can verify the error message for not selecting any interest
		Then I select a valid <SelectInterest>
		Then I verify the default value of miles dropdown
		Then I enter an invalid <Postcode>
		Then I click on Serach button
		Then I can verify the error message for invalid postcode

		Examples: 
		| SelectInterest                | Postcode |
		| Engineering and manufacturing | 123456   |
		| Care services					| AS$$TT55 |
		| Care services					|		   |


	Scenario: Check all the links and content of YOUR APPRENTICESHIP screen
		Given I navigate to Fire It Up home page
		When I launch the Your Apprenticeship page
		Then I verify the content under What to bring, and other useful info section
		Then I verify the content under Meet your new team section
		Then I verify the content under What comes after my apprenticeship section