Feature: RE_SJ_01

@regression
@registration
@addpayedetails
Scenario: RE_SJ_01_Verify GG route skip journey
	Given an Employer creates an Account by skipping the add PAYE part
	When the Employer chooses to add PAYE from Account Home Page
	Then the Employer is able to add PAYE and Organisation to the Account