Feature: AC_CD_08_UnConfirmHowApprenticeshipDelivered

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_08_UnConfirmHowApprenticeshipDelivered
	Given an apprentice has created and validated the account
	Then the apprentice confirms 'How the apprenticeship will be delivered' section as NOT understood