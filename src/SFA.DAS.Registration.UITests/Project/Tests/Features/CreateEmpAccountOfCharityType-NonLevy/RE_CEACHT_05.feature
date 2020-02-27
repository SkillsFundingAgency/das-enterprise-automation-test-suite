Feature: RE_CEACHT_05

@regression
@registration
@addpayedetails
Scenario: RE_CEACHT_05_Create an Employer Account with Charity Type Org and verify Adding another Charity Type Org
	Given an Employer Account with Charity Type Org is created and agreement is Signed
	When the Employer initiates adding another Org of Charity2 Type
	Then the Employer is able check the details of the 2nd Charity Org added are displayed in the 'Check your details' page and Continue