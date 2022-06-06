Feature: EI_P3_01_NewLevyAc_NoApplicationPage

@regression
@addlevyfunds
@employerincentives
Scenario: EI_P3_01_NewLevyAc_NoApplicationPage
	Given an Employer creates a Levy Account and Signs the Agreement
	Then View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications