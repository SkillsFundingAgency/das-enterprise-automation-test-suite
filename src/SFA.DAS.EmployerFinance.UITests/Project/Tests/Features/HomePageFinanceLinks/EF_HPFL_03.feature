Feature: EF_HPFL_03

@regression
@employerfinance
@addpayedetails
Scenario: EF_HPFL_03 - Validate Home Page Finance section for a Levy User who has Signed the Agreement
	When an Employer creates a Levy Account and Signs the Agreement
	Then 'Your finances' link is displayed in the Finances section
	When the Employer navigates to 'Finance' Page
	Then 'View transactions', 'Download transactions' and 'Transfers' links are displayed