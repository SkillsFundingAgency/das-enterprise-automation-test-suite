Feature: LTM_02_Create_Levy_Transfer_Pledge
	Verify Create Levy Pledge pages and functionality

@levy_transfers
	Scenario: Create Levy Transfer
	Given I am logged in as a Levy Payer
	And I am on the Manage Apprenticeships Page
	When I click on view my transfers
	Then I am on the View Transfers Page

	When I click on Create A Transfers Pledge
	Then I am on the Find A Business Page

	When I click on Continue 
	Then I am on the Create A Transfers Pledge Page