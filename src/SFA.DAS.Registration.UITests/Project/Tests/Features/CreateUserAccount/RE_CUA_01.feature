Feature: RE_CUA_01

@regression
@registration
Scenario: RE_CUA_01_Create an User Account and Skip adding PAYE
	When an User Account is created
	Then My Account Home page is displayed when PAYE details are not added