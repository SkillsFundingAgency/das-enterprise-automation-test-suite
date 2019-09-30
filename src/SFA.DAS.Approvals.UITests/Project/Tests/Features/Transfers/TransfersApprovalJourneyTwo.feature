Feature: TransfersApprovalJourneyTwo

A short summary of the feature

@regression
@transfersscenarios
@liveapprentice
@transfersfunds
Scenario: Creating Cohort and approve by all 3 parties and second approval by provider
Given Receiver sends an approved cohort to the provider
When Provider approves the cohort
And Sender approves the cohort 
Then Verify a new live apprenticeship record is created

