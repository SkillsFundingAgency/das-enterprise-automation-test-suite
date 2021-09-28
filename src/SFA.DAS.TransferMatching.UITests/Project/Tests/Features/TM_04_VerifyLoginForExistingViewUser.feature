Feature: TM_04_VerifyLoginForExistingViewUser

@regression
@registration
Scenario: TM_04_Verify Login For Existing View user
	Given the Employer logins using existing view user account
	Then the user can not create transfer pledge