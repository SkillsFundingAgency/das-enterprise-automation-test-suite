
Feature: RE_NOTIF_02

@regression
@registration
@testinator
@verifyemailnotification
Scenario: RE_NOTIF_02_Veify Access code via mailinator api
	When the User initiates Account creation
	Then the User receives Access code notification to the registered email