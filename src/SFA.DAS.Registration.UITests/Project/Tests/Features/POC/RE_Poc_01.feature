
Feature: RE_Poc_01

@regression
Scenario Outline: RE_Poc_01_Using data helpers
	When the User initiates Account creation using <Userdetails> details and datahelper

	Examples: 
	| Userdetails |
	| valid       |
	| invalid     |
