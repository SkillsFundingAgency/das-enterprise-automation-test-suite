Feature: TransfersJourneyOne

A short summary of the feature

@regression
@transfersscenarios
@addpayedetails
Scenario: Creating Transfer Connection between Sender (Levy Employer) and Receiver (Levy|Non-Levy Employer)
Given We have a new Sender with sufficient levy funds and a new Receiver accounts setup
When Sender connects to Receiver
Then A transfer connection is established successfully 
