@approvals
Feature: AP_DH_01_ReservesFundingToAddAnApprentice
As a NonLevy Employer, I want to add an apprentice after funding is reserved from dynamic homepage

@regression
@dynamichomepage
@addpayedetails
Scenario: AP_DH_01 Employer reserves funding to add an apprentice from dynamic homepage journey
	Given The User creates Employer account and sign an agreement
	When  The Employer reserves funding for an apprenticeship course from reserved panel
	Then  The funding is successfully reserved
	And   The new reserved funding panel is shown to employer on the homepage
	And   The employer continues to add an apprentice for reserved funding
	And   TrainingProvider approves apprentice by adding further details