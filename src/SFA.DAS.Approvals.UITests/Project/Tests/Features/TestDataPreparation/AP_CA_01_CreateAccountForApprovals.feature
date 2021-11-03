Feature: AP_CA_01_CreateAccountForApprovals
#Do not add regression or approvals tag, as these tests are meant to create data


@addlevyfunds
Scenario: AP_CA_01_01 Create Levy Account For Approvals
	Given an User Account is created
	When the User adds PAYE details
	And adds Organisation details
	When the Employer is able to Sign the Agreement
	Then the Employer Home page is displayed

@addtransferslevyfunds
Scenario: AP_CA_01_02 Create Agreement Not Signed Transfers Account For Approvals
	Given an User Account is created
	When the User adds PAYE details
	And adds Organisation details
	When the Employer does not sign the Agreement
