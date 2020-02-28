@approvals
Feature: AP_DH_01_ReservesFundingToAddAnApprentices
As a Non Levy Employer, I want to add an apprentices after reserves funding from dynamic homepage

@regression
@dynamichomepage
@addpayedetails
Scenario: AP_DH_01 Employer reserves funding to add an apprentices from dynamic homepage journey
	When an User Account is created
	And the User adds PAYE details
	And adds Organisation details
	Then the Employer is able to Sign the Agreement
	Then the Employer Home page is displayed
	When the Employer reserves funding for an apprenticeship course from reserved panel
	Then the funding is successfully reserved
	And the new reserved funding panel is shown to employer on the homepage
	And the employer continue to add an apprentices for reserved funding