@approvals
Feature: TransfersStatusJourney

@regression
@transfersscenarios
Scenario: Transfers - Verify transfer status when agreement is not signed
	Given We have a Sender with sufficient levy funds without signing an agreement
	Then the sender transfer status is disabled

@regression
@transfersscenarios
Scenario: Transfers - Verify transfer status when agreement is signed
	Given We have a Sender with sufficient levy funds
	Then the sender transfer status is enabled