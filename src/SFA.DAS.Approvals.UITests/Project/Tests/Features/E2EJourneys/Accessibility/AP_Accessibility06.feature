@accessibility
@registration
Feature: AP_E2E_ACC_Accessibility06
Navigation journey through EAS and PAS 

@addnonlevyfunds
Scenario: AP_E2E_ACC_06_Verify adding a Team member as viewer
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then Employer is able to invite a team member with Viewer access
	And Employer is able to resend an invite
	And Employer is able abort cancelling during cancelling an invite
	And Employer is able to cancel an invite
	And the invited team member is able to accept the invite and login to the Employer account
	And Employer is able to Remove the team member from the account
