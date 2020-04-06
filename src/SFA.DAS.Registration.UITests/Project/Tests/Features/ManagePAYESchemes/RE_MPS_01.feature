Feature: RE_MPS_01

@regression
@registration
@addpayedetails
@addanothernonlevypayedetails
Scenario: RE_MPS_01_Create an Employer Account and add another NonLevy PAYE Scheme and Remove it
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to Add Another NonLevy PAYE scheme to the Account
	And the Employer is able to Remove the second PAYE scheme added from the Account