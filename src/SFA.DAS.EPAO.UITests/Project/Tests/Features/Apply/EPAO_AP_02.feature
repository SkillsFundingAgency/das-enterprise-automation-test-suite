Feature: EPAO_AP_02

@epao
@epaoapply
@regression
Scenario: EPAO_AP_02A - Validate SignIn and SignOut
	When the Apply User is logged into Assessment Service Application
	Then the User Name is displayed in the Logged In Home page
	And the Apply User is able to Signout from the application

@epao
@epaoapply
@regression
Scenario: EPAO_AP_02B - Validate Organisation Search funcationality
	When the Apply User is logged into Assessment Service Application
	Then the Apply User is able to Signout from the application