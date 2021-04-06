Feature: AC_CA_01_ConfirmApprenticeship

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CA_01_ConfirmApprenticeship
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the apprenticeship details
	And confirmed apprenticeship already page is displayed for trying to confirm again