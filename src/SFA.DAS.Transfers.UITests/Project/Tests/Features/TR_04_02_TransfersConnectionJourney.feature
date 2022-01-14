@approvals
@transfers
Feature: TR_04_02_TransfersConnectionJourney

@regression
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds

Scenario: TR_04_02 Transfers - Sucessfully create Transfer Request from Receiver to another Account
	Given We have three Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Second account creates transfer request to Third account and Third account accepts the request
	Then A transfer connection is established successfully between Second account as Sender and Third account as Receiver