Feature: AC_E2E_01_PositiveE2EJourney

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_E2E_01_PositiveE2EJourney
	Given an apprentice has created and validated the account
	When the apprentice confirms all the Apprenticeship sections
	Then the apprentice is able to confirm the Overall Apprenticeship status