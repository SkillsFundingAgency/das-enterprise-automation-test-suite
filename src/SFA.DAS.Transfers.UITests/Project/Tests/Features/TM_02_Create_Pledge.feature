Feature: TM_02_Create_Pledge
	Create Pledge available to Owner and Transactor Roles

@levy_transfers
Scenario: User with Owner Role can create a Pledge
	Given User is logged in with an Owner Account
	And They have access to create a Pledge
	Then They can create a pledge up to the available funds amaount
	And They cannot exceed the maximum funding available
	
Scenario: User with Transactor Role can create a Pledge
	Given User is logged in with an Transactor Account
	And They have access to create a Pledge
	Then They can create a pledge up to the available funds amaount
	And They cannot exceed the maximum funding available

Scenario: User with Viewer Role can not create a Pledge
	Given User is logged in with an Transactor Account
	Then They do not have access to create a pledge

Scenario: User with Owner Role can create an Anonymous Pledge
	Given User is logged in with an Transactor Account
	And They have access to create a Pledge
	And They can choose to hise the Company Name on the Pledge
	Then They can create a pledge up to the available funds amaount
	And They cannot exceed the maximum funding available