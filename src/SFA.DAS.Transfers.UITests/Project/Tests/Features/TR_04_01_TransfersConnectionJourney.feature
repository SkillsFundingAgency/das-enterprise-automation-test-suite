Feature: TR_04_01_TransfersConnectionJourney

@regression
@approvals
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
Scenario: TR_04_01 Transfers - Sucessfully create Transfer Connection between Employer Accounts
	Given We have two Employer accounts
	When First account creates a transfer connection request to Second account
	Then Second account has '1 connection request to review' task link
	When Second account accepts the transfer connection request from First account
	Then Second account has no '... connection request(s) to review' task link
	And A transfer connection is established successfully between First account as Sender and Second account as Receiver