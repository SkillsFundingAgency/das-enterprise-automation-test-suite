Feature: EF_HPFLNU_02

@regression
@employerfinance
@addpayedetails
Scenario: EF_HPFLNU_02 - Validate Home Page Finance section for a NonLevy Employer who has not Signed the Agreement
	When an Employer creates a Non Levy Account and not Signs the Agreement during registration
	And Signs the Agreement from Account HomePage Panel
	Then  'Your funding reservations' and 'Your finances' links are displayed in the Finances section
	When the Employer navigates to 'Finance' Page
	Then 'View transactions', 'Download transactions' and 'Transfers' links are displayed