Feature: AC_CD_07_ConfirmHowApprenticeshipDelivered

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_07_ConfirmHowApprenticeshipDelivered
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm 'How the apprenticeship will be delivered' section
	And confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again