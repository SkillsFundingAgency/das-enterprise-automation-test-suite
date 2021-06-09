Feature: LTM_01_View_Levy_Transfers
	Log in as a Levy Paying User and View Transfers

@levy_transfers


Scenario: View Levy Transfers
	Given I am logged in as a Levy Payer
	And I am on the Manage Apprenticeships Page
	When I click on view my transfers
	Then I am taken to the View Transfers Page