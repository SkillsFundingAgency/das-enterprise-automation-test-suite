Feature: EmployerAddsApprenticeshiptoFavourite
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

Scenario: I want to be able Save an Apprenticeship
	Given I navigate to Fire It Up home page
	And I Launch Find The Right Apprenticeship page
	Then I Verify the title for Find The Right Apprenticeship  page
	And I Can Perform The Search on the Empty Field
	And I Can Verify The Result Page
	And I Can Add Apprenticeships From Search Result by Clicking On the Title
