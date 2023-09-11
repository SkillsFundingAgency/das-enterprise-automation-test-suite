@accessibility
@employerfinance
Feature: EF_Accessibility

@employerfinance
Scenario: EF_ACC_01 - Verify Finance pages navigation for Existing Levy Employer
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then Employer is able to navigate to 'View transactions', 'Download transactions', 'Funding projection' and 'Transfers' pages
	When the Employer navigates to 'Finance' Page
	Then Employer can add, edit and remove apprenticeship funding projection