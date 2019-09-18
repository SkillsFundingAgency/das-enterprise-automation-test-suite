Feature: TransfersJourneyOne

A short summary of the feature

@regression
@transfersscenarios
@addpayedetails
Scenario: Creating Transfer Connection between Sending and Reveiving Employers
Given the Employer has sufficient levy declarations for transfers 
Given the User creates Employer account and sign an agreement
And the User adds Receiver Employer account and sign an agreement
When the Employer connects to receiving employer
Then A connection between sender and receiver is established successfully

