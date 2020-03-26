Feature: RE_SJ_02

@regression
@registration
@addpayedetails
Scenario: RE_SJ_02_Verify AORN route skip journey
	Given an Employer creates an Account by skipping to add PAYE details after choosing AORN route
	When the Employer chooses to add PAYE from Account Home Page
	Then the Employer is able to add AORN details attached to a SingleOrg to the Account