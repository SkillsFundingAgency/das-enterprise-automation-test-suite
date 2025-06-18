Feature: TR_02_TransfersApprovalJourney

@regression
@transfers
@liveapprentice
@addtransferslevyfunds
@addsecondlevyfunds
Scenario: TR_02 Transfers - Creating Cohort and approve by all 3 parties and second approval by provider
	Given We have two Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Receiver Second sends approved cohort using transfer funds from Sender First with 2 apprentices to the provider for review and approval
	And Provider approves the cohort
	Then 'Transfer request received' task link is displayed under Tasks pane for the Sender First account
	When Sender First approves the cohort
	Then No 'Transfer request received' task link is displayed under Tasks pane for the Sender First account
	And Receiver Second has a new live apprenticeship record created
