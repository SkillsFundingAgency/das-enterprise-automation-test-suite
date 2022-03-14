Feature: AC_CD_03_ConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_03_ConfirmYourTrainingProvider
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the Training Provider
	And confirmed training provider already page is displayed for trying to confirm again
	And the apprentice is able to change the answer and choose to confirm the Provider details as Incorrect
	And an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm provider page