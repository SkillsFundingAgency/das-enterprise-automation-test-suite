Feature: TransfersApprovalJourney

A short summary of the feature

@regression
@transfersscenarios
@liveapprentice
@transfersfunds
Scenario: Creating a Cohort and Approve by all 3 parties
Given Receiver sends a cohort to the provider for review and approval
When Provider adds an apprentices approves the cohort
When Receiver approves the cohort
When Sender approves the cohort
Then Verify the new live apprenticeship record is created

