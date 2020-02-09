Feature: RV1_CTVD_01
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@raa-v1
@v1_e2e
@regression
Scenario: RV1_CTVD_01 - Change Vacancy dates which has NO Applications
	Given the traineeship vacancy is Live in Recruit with no application
	Then Provider is able to change vacancy dates with no application
	And the Trainneship Vacancy dates is changed in FAA
