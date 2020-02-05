@registration
Feature: RE_EA_01_ExistingLevyAccount

@regression
Scenario: RE_EA_01_01_Existing Levy Account
	Given the Employer login using existing levy account
	Then I will land in the User Home page

@regression
Scenario: RE_EA_01_02_Existing NonLevy Account
	Given the Employer login using existing non levy account
	Then I will land in the User Home page