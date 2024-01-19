Feature: RP_CA_PF_01

@roatpapplycreateaccount
@donottakescreenshot
@perftestroatpapplycreateaccount
Scenario Outline: RP_CA_PF_01_Create_Account_TestData
	Then user submits the details to create an account
	| GivenName   | FamilyName   |
	| <GivenName> | <FamilyName> |
		Examples: 
		| GivenName        | FamilyName |
		| sudhakar.chinoor | +test      |

