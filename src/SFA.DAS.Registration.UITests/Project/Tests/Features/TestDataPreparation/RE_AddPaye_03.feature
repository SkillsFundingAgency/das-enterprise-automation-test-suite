Feature: RE_TD_AddPaye_03

@regression
@registration
@addlevyfunds
@addmultiplelevyfunds
@addmultiplelevyfundstestdatascenario
Scenario: RE_TD_AddPaye_03 Add Paye to existing employer
	When the Employer logins using existing AddMultiplePayeLevyUser Account
	Then the Employer is able to Add multiple Levy PAYE scheme to the Account