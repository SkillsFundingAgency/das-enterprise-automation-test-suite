Feature: TR_03_TransfersApprovalJourney

@regression
@approvals
@transfers
@liveapprentice
Scenario: TR_03 Transfers - Creating Cohort rejected by Sender and then approved by all 3 parties
	Given Receiver sends an approved cohort with 1 apprentices to the provider
	When the Provider approves the cohort
	And Sender rejects the cohort
	And Receiver edits and sends an approved cohort to the provider
	And the Provider approves the cohort
	And Sender rejects the cohort
	When Receiver sends a cohort to the provider for review and approval
	And Provider approves the cohort and sends to recevier for approval
	And Receiver approves the cohort
	And Sender approves the cohort
	Then Verify a new live apprenticeship record is created
