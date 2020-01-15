Feature: EmployerSelectsAnApprenticeshipFromTheSearchResultList
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@campaign
@regression
Scenario: Check That Employer is Able To Select An Apprenticeship From The  Search Result
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I Launch Find The Right Apprenticeship page
	Then I Verify the title for Find The Right Apprenticeship  page
	And I Can Perform The Search on the Empty Field
	And I Can Verify The Result Page
	And I Can Select An Apprenticeship From Search Result  List