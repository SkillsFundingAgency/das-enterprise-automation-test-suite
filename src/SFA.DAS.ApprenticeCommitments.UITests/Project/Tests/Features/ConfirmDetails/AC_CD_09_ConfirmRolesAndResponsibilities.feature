Feature: AC_CD_09_ConfirmRolesAndResponsibilities

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_09_ConfirmRolesAndResponsibilities
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm Roles and responsibilities
	And confirmed Roles already page is displayed for trying to confirm again