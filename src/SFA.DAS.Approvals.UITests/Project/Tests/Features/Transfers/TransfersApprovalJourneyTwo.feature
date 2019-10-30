@approvals
Feature: TransfersApprovalJourneyTwo

@regression
@transfersscenarios
@liveapprentice
@transfersfunds
Scenario: Transfers - Creating Cohort and approve by all 3 parties and second approval by provider
	Given Receiver sends an approved cohort to the provider
	When Provider approves the cohort
	And Sender approves the cohort
	Then Verify a new live apprenticeship record is created