
Feature: LTM_01_View_Levy_Transfers
	Log in as a Levy Paying User and View Transfers

@levy_transfers
Scenario: View Levy Transfers
	Given I am logged in as a Levy Payer
	And I am on the Manage Apprenticeships Page
	When I click on view my transfers
	Then I am on the View Transfers Page

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