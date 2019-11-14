@approvals
Feature: TransfersApprovalJourneyThree

@inprogress
@transfersscenarios
@liveapprentice
@transfersfunds
Scenario: Transfers - Creating Cohort rejected by Sender and then approved by all 3 parties
	Given Receiver sends an approved cohort to the provider
	When Provider approves the cohort
	And Sender rejects the cohort
	And Receiver edits and sends an approved cohort to the provider
	And Provider approves the cohort
	And Sender rejects the cohort
	When Receiver sends a cohort to the provider for review and approval
	And Provider approves the cohort and sends to recevier for approval
	And Receiver approves the cohort
	And Sender approves the cohort
	Then Verify a new live apprenticeship record is created