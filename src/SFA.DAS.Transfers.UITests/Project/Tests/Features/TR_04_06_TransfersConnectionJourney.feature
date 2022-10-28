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
	Then Second account has '1 connection request to review' task link
	When Third account creates a transfer connection request to Second account
	Then Second account has '2 connection requests to review' task link
	When Second account accepts the transfer connection request from First account
	Then Second account has '1 connection request to review' task link
	And A transfer connection is established successfully between First account as Sender and Second account as Receiver
	When Second account accepts the transfer connection request from Third account
	Then Second account has no '... connection request(s) to review' task link
	And A transfer connection is established successfully between Third account as Sender and Second account as Receiver