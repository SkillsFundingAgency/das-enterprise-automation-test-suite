Feature: RE_CEAONRdb_01

@regression
@registration
@addpayedetails
Scenario: RE_CEAONRdb_01_Create an Employer Account with with Org not in Companies House, Charity Commission or ONS
	Given an User Account is created
	And the User adds PAYE details
	When the Employer Creates a new organisation and adds the details manually
	Then the Employer is able check the details entered manually in the 'Check your details' page and complete registration