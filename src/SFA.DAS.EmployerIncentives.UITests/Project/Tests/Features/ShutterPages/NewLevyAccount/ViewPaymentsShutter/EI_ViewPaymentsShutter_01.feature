Feature: EI_ViewPaymentsShutter_01

@regression
@addlevyfunds
@employerincentives
Scenario: EI_ViewPaymentsShutter_01_Create a new Levy Account and verify View payments shutter page
	Given an Employer creates a Levy Account and Signs the Agreement
	Then View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications