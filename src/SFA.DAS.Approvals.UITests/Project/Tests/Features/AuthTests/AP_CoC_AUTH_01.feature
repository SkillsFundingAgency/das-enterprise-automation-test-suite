Feature: AP_CoC_AUTH_01

@authtests
@approvals
@regression
@ignoreintest
@ignoreintest2
@ignoreinpp
@ignoreindemo
Scenario: AP_CoC_AUTH_01 Employer requests change to dob and reference After ILR match and Provider approves
	Given the Employer has approved apprentice
	When the Employer edits Dob and Reference and confirm the changes after ILR match
	Then the provider can review and approve the changes
	Then an unauthorised user can not access the service
	And a valid user can not access different account