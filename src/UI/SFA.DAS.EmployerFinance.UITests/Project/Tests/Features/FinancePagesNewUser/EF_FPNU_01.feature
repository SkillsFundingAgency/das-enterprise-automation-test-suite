Feature: EF_FPNU_01

@regression
@employerfinance
@addlevyfunds
Scenario: EF_FPNU_01 - Verify Finance pages navigation for A New Levy Employer
	When an Employer creates a Levy Account and Signs the Agreement
	And the Employer navigates to 'Finance' Page
	Then Employer is able to navigate to 'View transactions', 'Download transactions', 'Funding projection' and 'Transfers' pages