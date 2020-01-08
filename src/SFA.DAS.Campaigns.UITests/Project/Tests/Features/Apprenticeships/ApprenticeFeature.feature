Feature: ApprenticeFeature 

	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

	@regression
	Scenario: User can see a valid message when no apprentice results found
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		And I Click on Find An Apprenticeship option in the Menu Bar Header
		When I select a valid Care services
		And I enter a valid SW1V 3LP
		And I select miles 5 miles
		And I click on Serach button
		Then I can verify the content of no matching results page

	@regression
	Scenario Outline: Application should show default value for Miles DropDown and valid error messages for invalid postcode and interest selection
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		And I Click on Find An Apprenticeship option in the Menu Bar Header
		When I click on Serach button
		Then I can verify the error message for not selecting any interest
		When I select a valid <SelectInterest>
		Then I verify the default value of miles dropdown
		When I enter an invalid <Postcode>
		And I click on Serach button
		Then I can verify the error message for invalid postcode

		Examples: 
		| SelectInterest                | Postcode |
		| Engineering and manufacturing | 123456   |
		| Care services					| AS$$TT55 |
		| Care services					|		   |

