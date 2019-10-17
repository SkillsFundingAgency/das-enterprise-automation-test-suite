Feature: TransfersConnectionJourney

@regression
@transfersscenarios
@addpayedetails
@addtransferslevyfunds
Scenario: Transfers - Creating Transfer Connection between Sender and Receiver
	Given We have a new Sender with sufficient levy funds and a new Receiver accounts setup
	When Sender connects to Receiver
	Then A transfer connection is established successfully