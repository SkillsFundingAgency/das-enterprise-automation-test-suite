Feature: TR_04_02_TransfersConnectionJourney

@regression
@approvals
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds
Scenario: TR_04_02 Transfers - Sucessfully create Transfer Connection from existing Receiver to existing Sender Account
	Given We have three Employer accounts
	And First is a Sender connected to Second as a Receiver
	And Third is a Sender connected to First as a Receiver
	When Second account creates transfer request to Third account and Third account accepts the request
	Then A transfer connection is established successfully between Second account as Sender and Third account as Receiver