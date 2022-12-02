Feature: FLP_TR_03_TransfersApprovalJourney

@regression
@liveapprentice
@flexi-payments
Scenario: FLP_TR_03 Transfers - Creating Cohort rejected by Sender and then approved by all 3 parties
	Given Receiver sends an approved cohort with 1 apprentices to the provider
	When the provider adds Ulns and opts the learners out of the pilot
	And Provider is able to successfully approve the cohort
	And Sender rejects the cohort
	And Receiver edits and sends an approved cohort to the provider
	And the Provider approves the cohort
	And Sender rejects the cohort
	And Receiver sends a cohort to the provider for review and approval
	And Provider approves the cohort and sends to recevier for approval
	And Receiver approves the cohort
	And Sender approves the cohort
	Then Verify a new live apprenticeship record is created