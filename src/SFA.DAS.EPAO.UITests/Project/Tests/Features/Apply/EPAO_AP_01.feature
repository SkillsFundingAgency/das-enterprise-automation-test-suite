@resetapplyuserorganisationid
Feature: EPAO_AP_01

@epao
@epaoapply
@regression
Scenario: EPAO_AP_01A - Apply to become Assessor Happy path
	Given the Apply User is logged into Assessment Service Application
	When the Apply User completes preamble journey
	And the Apply User completes Organisation details section
	And the Apply User completes the Declarations section
	And the Apply User completes the FHA section
	Then the application is allowed to be submitted

@epao
@epaoapply
@regression
Scenario: EPAO_AP_01B - Validate SignIn and SignOut
	When the Apply User is logged into Assessment Service Application
	Then the User Name is displayed in the Logged In Home page
	And the Apply User is able to Signout from the application

@epao
@epaoapply
@regression
Scenario: EPAO_AP_01C - Validate Organisation Search funcationality
	When the Apply User is logged into Assessment Service Application
	Then no matches are shown for Organisation searches with Invalid search term