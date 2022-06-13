Feature: EI_P3_02_ExistingLevyAc_NoApplicationPage

@regression
@employerincentives
Scenario: EI_P3_02_ExistingLevyAc_NoApplicationPage
	Given the Employer logins using existing ei no application user
	Then View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications