Feature: RE_FYP_01

@regression
@registration
Scenario: RE_FYP_01_Verify Forgot Password feature
	When an Employer Account with Company Type Org is created
	Then the User is able to reset password using 'Forgot your password' link on SignIn Page