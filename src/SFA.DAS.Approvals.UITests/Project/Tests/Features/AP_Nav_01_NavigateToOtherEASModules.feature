Feature: AP_Nav_01

@approvals
@regression
@addpayedetails
Scenario: AP_Nav_01 Navigate Back and Forth from 'Apprentices' Page to all EAS Top Menu links
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to navigate back and forth from Apprentices to 'Finance' Page
	And the Employer is able to navigate back and forth from Apprentices to 'Your Team' Page
	And the Employer is able to navigate back and forth from Apprentices to 'Your organisations and agreements' Page
	And the Employer is able to navigate back and forth from Apprentices to 'PAYE schemes' Page