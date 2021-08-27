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

	When I click on the Amount You Want To Pledge Link
	Then I am on Pledge Amount And Org Name Page
	And I enter Transfer Amount of '22000'
	And I enter Transfer Amount using comma separator of '22,123'
	And I select 'Yes' to Organisation Name Shown Publicly

	When I click on Pledge Amount Continue
	Then I am on the Create A Transfers Pledge Page

	And the Submit Your Transfer Pledge Button is displayed

	When I click on Submit My Pledge
	Then I am on the Your Pledge Has Been Created Screen

	And I store the newly created pledge ID

	When I click on View Your Pledges
	Then I am taken to the My Transfer Pledges page
	And the created pledge appears on the page