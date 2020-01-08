Feature: EmployerRemovesProviderFromTheApprenticeship
	As an Employer
	I want to be able to navigate to Fire It Up home page
	So that I can use the benefits of Employer services and information 

@regression
Scenario: I want to be able to Remove Apprenticeships from the Favourite Short List
	Given I navigate to Fire It Up home page
	And I click on th Employer option in the Menu header
	And I Launch Find The Right Apprenticeship page
	Then I Verify the title for Find The Right Apprenticeship  page
	And I Can Perform The Search on the Empty Field
	And I Can Verify The Result Page
	And I Can Add Apprenticeships From Search Result  List to Favourite Short List
	And I Can Click on the Favourite Icon with Apprenticeship
	Then I Can Add a Provider to an Apprenticeship in the Shortlist Favourite
	And I Can Click on the Favourite Icon with Apprenticeship
	Then I Can Verify the Favourite Count for Provider
	And I Can Remove Provider from the Shortlist Favourite