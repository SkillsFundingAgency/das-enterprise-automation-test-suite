Feature: CreateAccountForApprovals

#Do not add regression tag as these test are meant to create data

@addpayedetails
@addlevyfunds
Scenario: Create Levy Account For Approvals
	Given I create an Account
	When I add paye details
	And add organisation details
	When I sign the agreement
	Then I will land in the User Home page


@addtransferslevyfunds
@addpayedetails
Scenario: Create Agreement Not Signed Transfers Account For Approvals
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
