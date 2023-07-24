Feature: TR_04_04_TransfersConnectionJourney

@regression
@transfers
@addtransferslevyfunds
@addsecondlevyfunds
@addthirdlevyfunds
Scenario: TR_04_04 Transfers - Sucessfully create Transfer Connection from Receiver back to its Sender
	Given We have two Employer accounts
	And First is a Sender connected to Second as a Receiver
	When Second account creates transfer request to First account and First account accepts the request
	Then A transfer connection is established successfully between Second account as Sender and First account as Receiver