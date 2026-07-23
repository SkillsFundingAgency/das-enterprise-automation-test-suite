Feature: AP_NL_E2E_05_NonLevyE2EJourneyThree

@approvals
@regression
@non-levy
@reservation
Scenario: AP_NL_E2E_05 Provider approves cohort and sends to Employer with reservation window for start date
    Given The Provider creates a reservation for a course
    When Provider try to use the reservation to add an apprentice with start date outside the reservation window
    Then Provider is stopped with an error message
