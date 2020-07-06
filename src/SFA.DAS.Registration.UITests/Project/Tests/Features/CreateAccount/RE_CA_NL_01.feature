Feature: RE_CA_NL_01

@nonlevy
@addpayedetails
Scenario: RE_CA_NL_01_Create a NonLevy Employer Account and Not Sign the Agreement
	When an Employer Account with Company Type Org is created and agreement is Not Signed
	Then ApprenticeshipEmployerType in Account table is marked as 0