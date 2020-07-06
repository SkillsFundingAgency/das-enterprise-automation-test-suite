Feature: RE_CA_LY_01

@levy
@addpayedetails
Scenario: RE_CA_LY_01_Create a Levy Account and Not Sign the Agreement
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	When an Employer Account with Company Type Org is created and agreement is Not Signed
	Then ApprenticeshipEmployerType in Account table is marked as 1