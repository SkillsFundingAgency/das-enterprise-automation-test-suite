Feature: EI_NAV_02_ApplicationsClosed

@regression
@employerincentives
Scenario: EI_NAV_02_ApplicationsClosed
	Given the Employer logins using existing EI Levy Account
	Then the Employer is able to view EI applications
	When the Employer switches to an account without apprentices
	Then the Applications open on 11 Jan 2022 page is shown