@approvals
Feature: AP_DH_01_ReservesFundingToAddAnApprentice
As a NonLevy Employer, I want to add an apprentice after funding is reserved from dynamic homepage

@regression
@dynamichomepage
@addpayedetails
Scenario: AP_DH_01 NonLevyEmployer reserves funding to add an apprentice from dynamic homepage journey
	Given The User creates NonLevyEmployer account and sign an agreement
	When  The NonLevyEmployer reserves funding for an apprenticeship course from reserved panel
	Then  The new reserved funding panel is shown to nonlevyemployer on the homepage
	And   The nonlevyemployer continues to add an apprentice for reserved funding
	And   The TrainingProvider approves apprentice by adding further details
	And   The NonLevyEmployer Reviews and Approves the apprentice