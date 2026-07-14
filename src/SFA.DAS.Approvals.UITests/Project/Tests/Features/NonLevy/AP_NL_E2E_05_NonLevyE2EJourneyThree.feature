Feature: AP_NL_E2E_05_NonLevyE2EJourneyThree

@approvals
@regression
@non-levy
@reservation
Scenario: AP_NL_E2E_05 Provider approves cohort and sends to Employer with reservation window for start date
	Given An Employer has given create reservation permission to a provider
    When The Provider creates a reservation for a course
    When Provider try to use the reservation to add an apprentice with start date outside the reservation window
    Then Provider is stopped with an error message
    When Provider use valid start date that aligns with reservation window to add 2 apprentices
    Then Provider can approve the cohort and send it to the Employer
