Feature: EF_HPFL_04

@regression
@employerfinance
@addpayedetails
Scenario: EF_HPFL_04 - Validate Home Page Finance section for a Levy User who has Not Signed the Agreement
	When an Employer creates a Levy Account and not Signs the Agreement during registration
	And Signs the Agreement from Account HomePage Panel
	Then 'Your finances' link is displayed in the Finances section
	When the Employer navigates to 'Finance' Page
	Then 'View transactions', 'Download transactions' and 'Transfers' links are displayed