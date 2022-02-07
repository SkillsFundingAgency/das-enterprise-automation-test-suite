@approvals
@transfers
Feature: TR_04_05_TransfersConnectionJourney

@regression
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds

Scenario: TR_04_05 Transfers - Sucessfully create Transfer Request from Account to Receiver
	Given We have three Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Third account creates transfer request to Second account and Second account accepts the request
	Then A transfer connection is established successfully between Third account as Sender and Second account as Receiver