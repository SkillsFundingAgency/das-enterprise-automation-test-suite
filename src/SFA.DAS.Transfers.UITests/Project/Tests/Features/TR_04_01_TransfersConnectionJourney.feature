Feature: TR_04_01_TransfersConnectionJourney

@regression
@approvals
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
Scenario: TR_04_01 Transfers - Sucessfully create Transfer Connection between Employer Accounts
	Given We have two Employer accounts
	When First account creates a transfer connection request to Second account
	Then '1 connection request to review' task link is displayed under Tasks pane for the Second account
	When Second account accepts the transfer connection request from First account
	Then No connection request(s) to review task links are displayed under Tasks pane for the Second account
	And A transfer connection is established successfully between First account as Sender and Second account as Receiver