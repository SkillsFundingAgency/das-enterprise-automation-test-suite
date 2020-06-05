Feature: RE_CLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CLEA_01_Create a Levy Account and Not Sign the Agreement
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	When an Employer Account with Charity Type Org is created and agreement is Not Signed
	Then ApprenticeshipEmployerType in Account table is marked as 1