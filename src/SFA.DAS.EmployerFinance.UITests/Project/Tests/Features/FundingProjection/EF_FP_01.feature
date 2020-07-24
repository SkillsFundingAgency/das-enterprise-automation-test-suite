Feature: EF_FP_01

@regression
@employerfinance
@waitingtostartapprentice
Scenario: EF_FP_01 - Verify Funding Projection pages navigation for Existing Levy Employer
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then Employer can add, edit and remove apprenticeship funding projection