Feature: TM_03_Apply_Receiver
	Receiver can apply to Pledges within Funding Limits for individual pledges
	But applications can have a cumulative total in excess of available funding

@levy_transfers
Scenario: Receiver can apply for Pledge up to the maximum available funds
	Given Receiver is logged in 
	Then They can view available opportunities
	And They can apply to a pledge up to the available funds amount
	And the Pledge details are displayed
	And The estimated cost of the Application in the current financial year is displayed
	And They can commit the Application

Scenario: Receiver can apply for Anonymous Pledge up to the maximum available funds
	Given Receiver is logged in 
	Then They can view available opportunities
	And They can apply to a pledge up to the available funds amount
	And the Pledge details are displayed
	And the Sender Name is not displayed
	And The estimated cost of the Application in the current financial year is displayed
	And They can commit the Application
	And the Sender Name is not displayed in confirmation

Scenario: Receiver can make multiple applications for the same available Pledge funds
	Given Receiver is logged in 
	Then They can view available opportunities
	And They can apply to again to a pledge up to the available funds amount
	And the Pledge details are displayed
	And The estimated cost of the Application in the current financial year is displayed
	And They can commit the Application

Scenario: Receiver cannot exceed maximum available Pledge funds in single application
	Given Receiver is logged in 
	Then They can view available opportunities
	And They can not apply to to a pledge in excess of the available funds amount
	And The estimated cost of the Application in the current financial year is displayed in Red
	And They can not commit the Application