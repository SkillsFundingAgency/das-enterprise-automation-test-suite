Feature: RAT2_P_OV_01

@rat-p
@regression
Scenario: RAT2_P_OV_01 - Provider creates Offline vacancy and QA approves
When the Provider creates an Offline vacancy
Then the Reviewer Approves the vacancy
