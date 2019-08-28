Feature: ApprenticeFeature 

	As a user
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of apprentice services and information 

	Scenario: User can find an apprentice from Apprenticeships home page
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		When I select a valid Care services
		And I enter a valid CV1 1DD
		And I select miles 40 miles
		And I click on Serach button
		Then I click on first search result
		And I can verify Apprentice Details Of Results Page Against Apprentice Details of Summary page

	Scenario: User can see a valid message when no apprentice results found
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
		When I select a valid Care services
		And I enter a valid SW1V 3LP
		And I select miles 5 miles
		And I click on Serach button
		Then I can verify the content of no matching results page

	Scenario Outline: Application should show default value for Miles DropDown and valid error messages for invalid postcode and interest selection
		Given I navigate to Fire It Up home page
		And I launch the Find An Apprentice page
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

	Scenario: Check all the links and content of YOUR APPRENTICESHIP screen
		Given I navigate to Fire It Up home page
		And I launch the Your Apprenticeship page
		Then I verify the content under What to bring, and other useful info section
		And I verify the content under Meet your new team section
		And I verify the content under What comes after my apprenticeship section

	Scenario: Check all the links and content of ASSESSMENT AND CERTIFICATION screen
		Given I navigate to Fire It Up home page
		And I launch the Assessment And Certification page
		Then I verify the content under Get assured and get your certificate section
		Then I verify the content under Complete your apprenticeship section

	Scenario: Check all the links and content of INTERVIEW screen
		Given I navigate to Fire It Up home page
		And I launch the Interview page
		Then I verify the content under The Interview Process section
		And I verify the content under Before Your Interview section
		And I verify the content under Day Of The Interview section

	Scenario: Check all the links and content of APPLICATION screen
		Given I navigate to Fire It Up home page
		And I launch the Application page
		Then I verify the content under SO, YOU'VE FOUND THE APPRENTICESHIP section
		And I verify the content under APPLY FOR THE JOB section
		And I verify the content under WAIT FOR THE APPLICATIONS section
		And I verify the content under IF YOU’RE ON THE SHORTLIST section
		And I verify the content under TRAINING PROVIDERS section

	Scenario: Check all the links and content of WAHT IS AN APPRENTICESHIP screen
		Given I navigate to Fire It Up home page
		And I launch the What Is An Apprenticeship page
		Then I verify the content under WHAT IS AN APPRENTICESHIP section
		And I verify the content under WHAT ARE THE DIFFERENT TYPES OF APPRENTICESHIPS section

	#Below scenario has been commented because of the bug https://skillsfundingagency.atlassian.net/browse/FC-832
	#Scenario: User can find an apprentice via MY INTERESTS page
	#	Given I navigate to Fire It Up home page
	#	And I launch the My Interests page
	#	Then I verify all the industry names on the My Interests page
	#	When I click on the industry name ENGINEERING AND MANUFACTURING
	#	And I can enter a valid post code CV1 1DD
	#	And I can select miles as 40 miles
	#	And I can click on search button
	#	Then I click on first search result
	#	And I can verify Apprentice Details Of Results Page Against Apprentice Details of Summary page

	Scenario: Check all the links and content of WHAT ARE THE BENEFITS FOR ME page
		Given I navigate to Fire It Up home page
		And I launch the What Are The Benefits For Me page
		Then I verify the content under WHAT ARE MY FUTURE PROSPECTS section
		And I verify the content under HOW MUCH CAN YOU EARN section
		And I verify the content under WHAT WILL MY APPRENTICESHIP COST ME section

	Scenario: Check all the links and content of REAL STORIES page
		Given I navigate to Fire It Up home page
		And I launch the Real Stories page
		Then I verify the content under Real Stories header
		And I can play the first video on the screen
