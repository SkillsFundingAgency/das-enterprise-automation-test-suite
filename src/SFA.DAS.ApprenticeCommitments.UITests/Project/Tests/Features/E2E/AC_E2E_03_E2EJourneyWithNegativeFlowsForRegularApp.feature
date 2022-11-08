Feature: AC_E2E_03_E2EJourneyWithNegativeFlowsForRegularApp

@apprenticecommitments
@regression
@deletecmaddatacreatedthroughapi
Scenario: AC_E2E_03_E2EJourneyWithNegativeFlowsForRegularApp
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the Employer
	And confirmed employer already page is displayed for trying to confirm again
	And the apprentice is able to change the answer and choose to confirm the Employer details as Incorrect
	And an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm employer page
	Then the apprentice is able to confirm the Training Provider
	And confirmed training provider already page is displayed for trying to confirm again
	And the apprentice is able to change the answer and choose to confirm the Provider details as Incorrect
	And an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm provider page
	Then the apprentice is able to confirm the Apprenticeship details
	And confirmed apprenticeship already page is displayed for trying to confirm again
	And the apprentice is able to change the answer and choose to confirm the Apprenticeship details as Incorrect
	And an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm details page
	Then the apprentice is able to confirm 'How the apprenticeship will be delivered' section
	And confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again
	Then the apprentice is able to confirm Roles and responsibilities by checking Negative flows
	And confirmed Roles page is displayed for trying to confirm again
	Then the apprentice confirms the overall apprenticeship