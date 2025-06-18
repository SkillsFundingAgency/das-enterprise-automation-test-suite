Feature: RE_CNLEA_01

@regression
@registration
@addnonlevyfunds
Scenario: RE_CNLEA_01_Create a NonLevy Employer Account and Not Sign the Agreement
	When an Employer Account with PublicSector Type Org is created and agreement is Not Signed
	Then ApprenticeshipEmployerType in Account table is marked as 0