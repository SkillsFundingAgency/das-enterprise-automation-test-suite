Feature: RE_CLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CLEA_01_Create a Levy Account
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	And an User Account is created
	When the User adds PAYE details
	And adds Organisation details
	And the Employer does not sign the Agreement
	Then the Employer Home page is displayed
	And ApprenticeshipEmployerType in Account table is marked as 1