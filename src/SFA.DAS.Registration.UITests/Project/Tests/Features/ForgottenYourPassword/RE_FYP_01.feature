Feature: RE_FYP_01

@regression
@registration
#Application is relaunched in this scenario due to Open defect in Live (AML-3026)
Scenario: RE_FYP_01_Verify Forgot Password feature
	When an User Account is created
	Then the User is able to reset password using 'Forgot your password' link on SignIn Page