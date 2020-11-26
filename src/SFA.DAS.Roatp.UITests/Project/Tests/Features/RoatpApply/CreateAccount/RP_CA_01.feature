Feature: RP_CA_01

@roatpapplycreateaccount
@roatp
@regression
Scenario: RP_CA_01_Create_Account
	When user submits the details to create an account
	Then the user is able to create an account using the invitation

		