@approvals
@transfers
Feature: TR_04_03_TransfersConnectionJourney

@regression
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds

Scenario: TR_04_03 Transfers - Sucessfully create Transfer Request from Receiver to Sender
	Given We have two Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Second account creates transfer request to First account and First account accepts the request
	Then A transfer connection is established successfully between Second account as Sender and First account as Receiver