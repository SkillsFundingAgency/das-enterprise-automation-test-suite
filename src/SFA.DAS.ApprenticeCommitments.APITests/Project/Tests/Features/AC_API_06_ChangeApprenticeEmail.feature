Feature: ChangeApprenticeEmail

@api
@apprenticecommitmentsapi
@outerapi
@regression
@deleteuser
Scenario: AC_API_06_An apprentice can change their email address
	Given an apprentice has created an account
	Then the apprentice can change their email address