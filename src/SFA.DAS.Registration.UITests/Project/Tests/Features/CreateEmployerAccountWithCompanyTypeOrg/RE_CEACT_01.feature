Feature: RE_CEACT_01

@regression
@registration
@addpayedetails
Scenario: RE_CEACT_01_Create an Employer Account with CompanyType Organisation
	When an User Account is created
	And the User adds PAYE details
	And adds Company Type Organisation details
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed