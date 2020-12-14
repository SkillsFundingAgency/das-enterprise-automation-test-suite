Feature: RE_MPS_02

@regression
@registration
@addlevyfunds
@addanotherlevyfunds
Scenario: RE_MPS_02_Create an Employer Account and Add Another Levy PAYE Scheme and Remove it
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to Add Another Levy PAYE scheme to the Account
	And the Employer is able to Remove the second PAYE scheme added from the Account