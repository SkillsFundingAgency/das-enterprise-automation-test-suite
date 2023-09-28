@accessibility
@employerfinance
Feature: EF_Accessibility02

Scenario: EF_ACC_02 - Verify Funding Projection pages navigation for Existing Levy Employer
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then Employer can add, edit and remove apprenticeship funding projection