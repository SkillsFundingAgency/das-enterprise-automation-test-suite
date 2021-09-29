Feature: TM_04_VerifyLoginForExistingViewUser

@regression
@transfermatching
Scenario: TM_04_Verify Login For Existing View user
	Given the Employer logins using existing view user account
	Then the user can not create transfer pledge
	And the user can view transfer pledge