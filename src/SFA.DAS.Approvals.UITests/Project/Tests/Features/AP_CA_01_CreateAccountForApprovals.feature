Feature: AP_CA_01_CreateAccountForApprovals

#Do not add regression or approvals tag as these test are meant to create data

@addpayedetails
@eoiaccount
Scenario: AP_CA_01_01 Create EOI Account For Approvals
	Given I create an Account
	When I add paye details
	And add eoi organisation details
	And I sign the eoi agreement
	Then I will land in the User Home page
	And the Employer can set create cohort and recruitment permissions

@addpayedetails
@addlevyfunds
Scenario: AP_CA_01_02 Create Levy Account For Approvals
	Given I create an Account
	When I add paye details
	And add organisation details
	When I sign the agreement
	Then I will land in the User Home page


@addtransferslevyfunds
@addpayedetails
Scenario: AP_CA_01_03 Create Agreement Not Signed Transfers Account For Approvals
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
