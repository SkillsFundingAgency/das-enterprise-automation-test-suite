Feature: EF_HPFLNU_01

@regression
@employerfinance
@addpayedetails
Scenario: EF_HPFLNU_01 - Validate Home Page Finance section for a NonLevy Employer who has Signed the Agreement
	When an Employer creates a Non Levy Account and Signs the Agreement
	Then 'Set up an apprenticeship' section is displayed
	And 'Your funding reservations' and 'Your finances' links are displayed in the Finances section
	When the Employer navigates to 'Finance' Page
	Then 'View transactions', 'Download transactions' and 'Transfers' links are displayed