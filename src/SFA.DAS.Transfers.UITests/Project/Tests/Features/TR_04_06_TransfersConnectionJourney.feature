Feature: TR_04_06_TransfersConnectionJourney

@regression
@approvals
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds
Scenario: TR_04_06 Transfers - Sucessfully create Transfer Connections between two sender Accounts and a single receiver Account
	Given We have three Employer accounts
	When First account creates a transfer connection request to Second account
	Then '1 connection request to review' task link is displayed under Tasks pane for the Second account
	When Third account creates a transfer connection request to Second account
	Then '2 connection requests to review' task link is displayed under Tasks pane for the Second account
	When Second account accepts the transfer connection request from First account
	Then '1 connection request to review' task link is displayed under Tasks pane for the Second account
	And A transfer connection is established successfully between First account as Sender and Second account as Receiver
	When Second account accepts the transfer connection request from Third account
	Then No connection request(s) to review task links are displayed under Tasks pane for the Second account
	And A transfer connection is established successfully between Third account as Sender and Second account as Receiver