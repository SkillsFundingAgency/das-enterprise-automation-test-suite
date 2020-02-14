@dynamicHomePage
Feature: DH_01_ReservesFunding
As a Non Levy Employer, I want to reserves funding form dynamic homepage
So that, I can add an apprentice

@regression
@dynamichomepagereservefunds
Scenario: DH_01 Employer reserves funding from homepage journey
	Given the Employer logins using existing NonLevy Account
	When the Employer reserves funding for an apprenticeship course from reserved panel
	Then the funding is successfully reserved
	And the new reserved funding panel is shown to employer on the homepage