Feature: TR_04_01_TransfersConnectionJourney

@regression
@approvals
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
Scenario: TR_04_01 Transfers - Sucessfully create Transfer Request between Employer Accounts
	Given We have two Employer accounts
	When First account creates transfer request to Second account and Second account accepts the request
	Then A transfer connection is established successfully between First account as Sender and Second account as Receiver