Feature: RE_MPS_01

@regression
@registration
@addpayedetails
@addanotherlevypayedetails
Scenario: RE_MPS_01_Create an Employer Account and add another Levy PAYE Scheme
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to Add Another Levy PAYE scheme to the Account