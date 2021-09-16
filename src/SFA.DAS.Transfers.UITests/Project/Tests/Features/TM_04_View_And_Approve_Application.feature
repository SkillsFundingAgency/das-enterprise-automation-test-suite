Feature: TM_04_View_And_Approve_Application
	Owner and Transactor can view pledges and associated applications
	And can approve applications where funding is available

@levy_transfers
Scenario: View Pledges and Applications and approve application within funding available
	Given User is logged in with an Owner Account
	Then They have access to View Pledges and Applications
	And They can View the Applications made to a Pledge
	And They can Approve an Application where the Funding Amount is not exceeded by Pledge
	And The remaining Pledge Funding is re-calculated and displayed
	And They can Commit the Approval


Scenario: View Pledges and Applications where funding exceeded by application
	Given User is logged in with an Transactor Account
	Then They have access to View Pledges and Applications
	And They can View the Applications made to a Pledge
	And They are unable to Approve an Application where the Funding Amount is exceeded by Pledge