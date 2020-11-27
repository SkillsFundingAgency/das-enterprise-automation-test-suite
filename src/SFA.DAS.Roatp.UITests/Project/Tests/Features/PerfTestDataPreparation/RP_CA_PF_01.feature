Feature: RP_CA_PF_01

@roatpapplycreateaccount
@donottakescreenshot
@perftestroatpapplycreateaccount
Scenario Outline: RP_CA_PF_01_Create_Account_TestData
	When user submits the details to create an account
	| GivenName   | FamilyName   |
	| <GivenName> | <FamilyName> |
	Then the user is able to create an account using the invitation
		Examples: 
		| GivenName        | FamilyName |
		| sudhakar.chinoor | +rpadmod01 |
		| sudhakar.chinoor | +rpadmod02 |
		| sudhakar.chinoor | +rpadmod03 |
		| sudhakar.chinoor | +rpadcla01 |
		| sudhakar.chinoor | +rpadcla02 |
