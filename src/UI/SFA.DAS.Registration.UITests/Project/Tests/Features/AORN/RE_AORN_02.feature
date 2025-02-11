Feature: RE_AORN_02

@regression
@registration
@addnonlevyfunds
Scenario: RE_AORN_02_Create an Employer Account through AORN route with paye details attached to a Multiple Organisations
	Given a User Account is created
	When the User adds PAYE details attached to a MultiOrg through AORN route
	Then the Employer Signs the Agreement
