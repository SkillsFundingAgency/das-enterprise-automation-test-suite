Feature: EI_NAV_01_ViewApplications

@regression
@employerincentives
Scenario: EI_NAV_01_ViewApplications
	Given the Employer logins using existing multiple account user
	Then the Employer is able to view EI applications
	When the Employer switches to an account without apprentices
	Then View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications