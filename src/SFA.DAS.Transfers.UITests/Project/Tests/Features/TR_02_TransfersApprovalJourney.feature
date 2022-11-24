Feature: TR_02_TransfersApprovalJourney

@regression
@approvals
@transfers
@liveapprentice
Scenario: TR_02 Transfers - Creating Cohort and approve by all 3 parties and second approval by provider
	Given Receiver sends an approved cohort with 2 apprentices to the provider
	When the Provider approves the cohort
	And Sender approves the cohort
	Then Verify a new live apprenticeship record is created