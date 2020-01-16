Feature: CheckTheParentLink
	As a Parent
	I want to be able to navigate to Fire It Up home page
	So that I can As a Parent get the relevant information on Apprenticeships

@campaigns
@regression
Scenario: Check the Parent Link
	Given I navigate to Fire It Up home page
	And I launch Help Shape Their Future Parents page
	Then I verify the Header on Parets page
