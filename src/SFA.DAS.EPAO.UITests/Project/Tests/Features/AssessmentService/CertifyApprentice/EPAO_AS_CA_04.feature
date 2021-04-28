Feature: EPAO_AS_CA_04

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_04A - Certify a privately funded Apprentice
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying a Privately funded Apprentice
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_04B - Attempt to certify a privately funded Apprentice with Invalid date
	Given the Assessor User is logged into Assessment Service Application
	And the User is on the Apprenticeship achievement date page
	When the User enters the date before the Year 2017
	Then An achievement date cannot be before 01 01 2017 is displayed in the Apprenticeship achievement date page
	When the User enters the future date
	Then An achievement date cannot be in the future is displayed in the Apprenticeship achievement date page