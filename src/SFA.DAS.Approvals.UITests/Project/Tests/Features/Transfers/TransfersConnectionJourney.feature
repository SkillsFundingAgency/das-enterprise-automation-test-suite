Feature: TransfersConnectionJourney

A short summary of the feature

@regression
@transfersscenarios
@addpayedetails
@addtransferslevyfunds
Scenario: Creating Transfer Connection between Sender and Receiver
Given We have a new Sender with sufficient levy funds and a new Receiver accounts setup
When Sender connects to Receiver
Then A transfer connection is established successfully 
