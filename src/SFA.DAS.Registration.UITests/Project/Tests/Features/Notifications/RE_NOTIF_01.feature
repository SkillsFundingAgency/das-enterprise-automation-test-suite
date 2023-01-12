
Feature: RE_NOTIF_01

@regression
@registration
@mailinator
Scenario: RE_NOTIF_01_Veify Access code notification receipt during Account creation
	When the User initiates Account creation
	Then the User receives Access code notification to the registered email

@regression
@registration
@testinator
Scenario: RE_NOTIF_02_Veify Access code via mailinator api
	When the User initiates Account creation
	Then mailinator api can access the inbox 