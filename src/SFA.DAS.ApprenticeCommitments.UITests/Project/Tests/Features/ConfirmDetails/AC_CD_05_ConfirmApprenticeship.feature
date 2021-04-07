Feature: AC_CD_05_ConfirmApprenticeship

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_05_ConfirmApprenticeship
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the Apprenticeship details
	And confirmed apprenticeship already page is displayed for trying to confirm again