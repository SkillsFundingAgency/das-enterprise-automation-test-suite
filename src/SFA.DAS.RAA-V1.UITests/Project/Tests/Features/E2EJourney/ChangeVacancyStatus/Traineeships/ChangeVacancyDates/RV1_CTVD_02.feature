Feature: RV1_CTVD_02
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@raa-v1
@regression
Scenario: RV1_CTVD_02 - Change Vacancy dates which has Applications
	Given the traineeship vacancy is Live in Recruit with an application
	Then Provider is able to change vacancy dates
	And the Trainneship Vacancy dates is changed in FAA
