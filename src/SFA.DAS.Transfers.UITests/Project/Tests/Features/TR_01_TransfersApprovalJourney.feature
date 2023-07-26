Feature: TR_01_TransfersApprovalJourney

@regression
@transfers
@liveapprentice
@addtransferslevyfunds
@addsecondlevyfunds
Scenario: TR_01 Transfers - Creating a Cohort and Approve by all 3 parties
	Given We have two Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Receiver Second sends empty cohort using transfer funds from Sender First to the provider for review and approval
	And Provider adds an apprentice and approves the cohort
	Then Receiver Second has '1 cohort request ready for approval' task link
	When Receiver Second approves the cohort
	Then Receiver Second has no '... cohort request(s) ready for approval' task link
	And 'Transfer request received' task link is displayed under Tasks pane for the Sender First account
	When Sender First approves the cohort
	Then No 'Transfer request received' task link is displayed under Tasks pane for the Sender First account
	And Receiver Second has a new live apprenticeship record created
