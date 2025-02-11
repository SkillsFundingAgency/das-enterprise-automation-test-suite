Feature: EF_FPEU_01

@regression
@employerfinance
Scenario: EF_FPEU_01 - Verify Finance pages navigation for Existing Levy Employer
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then Employer is able to navigate to 'View transactions', 'Download transactions', 'Funding projection' and 'Transfers' pages